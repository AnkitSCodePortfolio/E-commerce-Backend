using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace HomeAPI.DataAccessor
{
    public class DataAccessor : IDataAccessor
    {
        private readonly IConfiguration config;

        public DataAccessor(IConfiguration config)
        {
            this.config = config;
        }

        DataSet IDataAccessor.databaseStoredProcedureTransaction(string spName, Dictionary<string, object> parameters)
        {
            var connectionString = config.GetConnectionString("MyConnection");
            SqlConnection sqlconn = new SqlConnection(connectionString);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand command = new SqlCommand(spName, sqlconn);
                command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, object> entry in parameters)
                {
                    command.Parameters.AddWithValue(entry.Key, entry.Value);
                }

                sqlconn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds);
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                string msg = "";
                msg += ex.Message;
                throw new Exception(msg);

            }
            finally
            {
                sqlconn.Close();
            }
            return ds;

        }
        public DataSet RunQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(config.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, object> parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataSet);
                    }
                }
            }
            return dataSet;
        }
    }
}
