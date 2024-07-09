using System.Data;

namespace HomeAPI.DataAccessor
{
    public interface IDataAccessor
    {
        public DataSet databaseStoredProcedureTransaction(string v, Dictionary<string, object> objectDictionary);
        DataSet RunQuery(string query, Dictionary<string, object> parameters = null);
    }
}
