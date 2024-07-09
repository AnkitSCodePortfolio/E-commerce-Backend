using HomeAPI.DataAccessor;
using HomeAPI.DBContext;
using HomeAPI.DTO;
using HomeAPI.IRepository;
using HomeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HomeAPI.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly HomeDBContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDataAccessor accessor;
        private readonly IConfiguration config;

        public HomeRepository(HomeDBContext context, IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,IDataAccessor accessor,IConfiguration config)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.accessor = accessor;
            this.config = config;
        }

        public List<AppliancesCarousel?> AppliancesCarouselById(int Id)
        {
            List<AppliancesCarousel> homelist = new List<AppliancesCarousel>();
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                objectDictionary.Add("@Id", Id);
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("GetApplianceById").Value, objectDictionary);
                DataColumnCollection columns = ds.Tables[0].Columns;

                homelist = ds.Tables[0].AsEnumerable().Select(row =>
                   new AppliancesCarousel
                   {
                       Id = columns.Contains("Id") ? row.Field<int>("Id") : 0,
                       Price = columns.Contains("Price") ? row.Field<string>("Price") : "",
                       Name = columns.Contains("Name") ? row.Field<string>("Name") : "",
                       Description = columns.Contains("Description") ? row.Field<string>("Description") : "",
                       FilePath = columns.Contains("FilePath") ? row.Field<string>("FilePath") : "",
                   }).ToList();
                return homelist;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }

        }
        public List<FashionCarousel?> FashionCarouselById(int Id)
        {
            List<FashionCarousel> homelist = new List<FashionCarousel>();
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                objectDictionary.Add("@Id", Id);
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("GetFashionById").Value, objectDictionary);
                DataColumnCollection columns = ds.Tables[0].Columns;

                homelist = ds.Tables[0].AsEnumerable().Select(row =>
                   new FashionCarousel
                   {
                       Id = columns.Contains("Id") ? row.Field<int>("Id") : 0,
                       Price = columns.Contains("Price") ? row.Field<string>("Price") : "",
                       Name = columns.Contains("Name") ? row.Field<string>("Name") : "",
                       Description = columns.Contains("Description") ? row.Field<string>("Description") : "",
                       FilePath = columns.Contains("FilePath") ? row.Field<string>("FilePath") : "",
                   }).ToList();
                return homelist;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }

        }
        public List<RecentBuyCarousel?> GetRecentBuyCarouselById(int Id)
        {
            List<RecentBuyCarousel> homelist = new List<RecentBuyCarousel>();
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                objectDictionary.Add("@Id", Id);
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("GetRecentById").Value, objectDictionary);
                DataColumnCollection columns = ds.Tables[0].Columns;

                homelist = ds.Tables[0].AsEnumerable().Select(row =>
                   new RecentBuyCarousel
                   {
                       Id = columns.Contains("Id") ? row.Field<int>("Id") : 0,
                       Price = columns.Contains("Price") ? row.Field<string>("Price") : "",
                       Name = columns.Contains("Name") ? row.Field<string>("Name") : "",
                       Description = columns.Contains("Description") ? row.Field<string>("Description") : "",
                       FilePath = columns.Contains("FilePath") ? row.Field<string>("FilePath") : "",
                   }).ToList();
                return homelist;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }

        }
        public List<HomeSlider?> HomeCarouselById(int Id)
        {
            List<HomeSlider> homelist = new List<HomeSlider>();
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                objectDictionary.Add("@Id", Id);
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("GetHomeById").Value, objectDictionary);
                DataColumnCollection columns = ds.Tables[0].Columns;

                homelist = ds.Tables[0].AsEnumerable().Select(row =>
                   new HomeSlider
                   {
                       Id = columns.Contains("Id") ? row.Field<int>("Id") : 0,
                       Price = columns.Contains("Price") ? row.Field<string>("Price") : "",
                       Name = columns.Contains("Name") ? row.Field<string>("Name") : "",
                       Description = columns.Contains("Description") ? row.Field<string>("Description") : "",
                       FilePath = columns.Contains("FilePath") ? row.Field<string>("FilePath") : "",
                   }).ToList();
                return homelist;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }

        }

        public  async Task<AppliancesCarousel> AppliancesCarouselCreate(AppliancesCarousel model)
        {
            var uploadedImage = await Upload(model.Image, new Image());
            model.FilePath = uploadedImage.FilePath;
            try
            {
                var objectdictionary = new Dictionary<string, object>();
                objectdictionary.Add("@Name", model.Name);
                objectdictionary.Add("@Price", model.Price);
                objectdictionary.Add("@Description", model.Description);
                objectdictionary.Add("@FilePath", model.FilePath);
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("CreateAppliance").Value, objectdictionary);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Id = Convert.ToDouble(ds.Tables[0].Rows[0]["Id"]);
                    return model;
                }
                return model;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);
            }
        }
        public async  Task<FashionCarousel> FashionCarouselCreate(FashionCarousel model)
        {
            var uploadedImage = await Upload(model.Image, new Image());
            model.FilePath = uploadedImage.FilePath;
            try
            {
                var objectdictionary = new Dictionary<string, object>();
                objectdictionary.Add("@Name", model.Name);
                objectdictionary.Add("@Price", model.Price);
                objectdictionary.Add("@Description", model.Description);
                objectdictionary.Add("@FilePath", model.FilePath);
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("CreateFashion").Value, objectdictionary);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Id = Convert.ToDouble(ds.Tables[0].Rows[0]["Id"]);
                    return model;
                }
                return model;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);
            }
        }
        public async  Task<HomeSlider> HomeCarouselCreate(HomeSlider model)
        {
            var uploadedImage = await Upload(model.Image, new Image());
            model.FilePath = uploadedImage.FilePath;
            try
            {
                var objectdictionary = new Dictionary<string, object>();
                objectdictionary.Add("@Name", model.Name);
                objectdictionary.Add("@Price", model.Price);
                objectdictionary.Add("@Description", model.Description);
                objectdictionary.Add("@FilePath", model.FilePath);
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("CreateHome").Value, objectdictionary);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Id = Convert.ToDouble(ds.Tables[0].Rows[0]["Id"]);
                    return model;
                }
                return model;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);
            }
        }
    
        public async  Task<RecentBuyCarousel> GetRecentBuyCarouselCreate(RecentBuyCarousel model)
        {
            var uploadedImage = await Upload(model.Image, new Image());
            model.FilePath = uploadedImage.FilePath;
            try
            {
                var objectdictionary = new Dictionary<string, object>();
                objectdictionary.Add("@Name", model.Name);
                objectdictionary.Add("@Price", model.Price);
                objectdictionary.Add("@Description", model.Description);
                objectdictionary.Add("@FilePath", model.FilePath);
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("CreateRecent").Value, objectdictionary);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Id = Convert.ToDouble(ds.Tables[0].Rows[0]["Id"]);
                    return model;
                }
                return model;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);
            }
        }
        public  string AppliancesCarouselDelete(int Id)
        {
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                objectDictionary.Add("@Id", Id);
                string res = "Record Deleted";

                DataSet ds = accessor.RunQuery(config.GetSection("deleteAppliance").Value, objectDictionary);

                return res;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }
        }
        public string HomeCarouselDelete(int Id)
        {
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                objectDictionary.Add("@Id", Id);
                string res = "Record Deleted";

                DataSet ds = accessor.RunQuery(config.GetSection("deleteHome").Value, objectDictionary);

                return res;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }
        }
        public string FashionCarouselDelete(int Id)
        {
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                objectDictionary.Add("@Id", Id);
                string res = "Record Deleted";

                DataSet ds = accessor.RunQuery(config.GetSection("deleteFashion").Value, objectDictionary);

                return res;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }
        }
        public string GetRecentBuyCarouselDelete(int Id)
        {
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                objectDictionary.Add("@Id", Id);
                string res = "Record Deleted";

                DataSet ds = accessor.RunQuery(config.GetSection("deleteRecent").Value, objectDictionary);

                return res;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }
        }

        public  Task<AppliancesCarousel?> AppliancesCarouselUpdate(int Id, AppliancesCarousel model)
        {
            throw new NotImplementedException();
        }
    
        public  Task<FashionCarousel?> FashionCarouselUpdate(int Id, FashionCarousel model)
        {
            throw new NotImplementedException();
        }
        public Task<RecentBuyCarousel?> GetRecentBuyCarouselUpdate(int Id, RecentBuyCarousel model)
        {
            throw new NotImplementedException();
        }

        public Task<HomeSlider?> HomeCarouselUpdate(int Id, HomeSlider model)
        {
            throw new NotImplementedException();
        }

        public List<AppliancesCarousel> GetAppliancesCarousel()
        {
            List<AppliancesCarousel> homelist = new List<AppliancesCarousel>();
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("GetAppliance").Value, objectDictionary);
                DataColumnCollection columns = ds.Tables[0].Columns;

                homelist = ds.Tables[0].AsEnumerable().Select(row =>
                   new AppliancesCarousel
                   {
                       Id = columns.Contains("Id") ? row.Field<int>("Id") : 0,
                       Price = columns.Contains("Price") ? row.Field<string>("Price") : "",
                       Name = columns.Contains("Name") ? row.Field<string>("Name") : "",
                       Description = columns.Contains("Description") ? row.Field<string>("Description") : "",
                       FilePath = columns.Contains("FilePath") ? row.Field<string>("FilePath") : "",
                   }).ToList();
                return homelist;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }

        }
        public List<FashionCarousel> GetFashionCarousel()
        {
            List<FashionCarousel> homelist = new List<FashionCarousel>();
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("GetFashion").Value, objectDictionary);
                DataColumnCollection columns = ds.Tables[0].Columns;

                homelist = ds.Tables[0].AsEnumerable().Select(row =>
                   new FashionCarousel
                   {
                       Id = columns.Contains("Id") ? row.Field<int>("Id") : 0,
                       Price = columns.Contains("Price") ? row.Field<string>("Price") : "",
                       Name = columns.Contains("Name") ? row.Field<string>("Name") : "",
                       Description = columns.Contains("Description") ? row.Field<string>("Description") : "",
                       FilePath = columns.Contains("FilePath") ? row.Field<string>("FilePath") : "",
                   }).ToList();
                return homelist;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }
        }

        public List<HomeSlider> GetHomeCarousel()
        {

            List<HomeSlider> homelist = new List<HomeSlider>();
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("GetHome").Value, objectDictionary);
                DataColumnCollection columns = ds.Tables[0].Columns;

                homelist = ds.Tables[0].AsEnumerable().Select(row =>
                   new HomeSlider
                   {
                       Id = columns.Contains("Id") ? row.Field<int>("Id") : 0,
                       Price = columns.Contains("Price") ? row.Field<string>("Price") : "",
                       Name = columns.Contains("Name") ? row.Field<string>("Name") : "",
                       Description = columns.Contains("Description") ? row.Field<string>("Description") : "",
                       FilePath = columns.Contains("FilePath") ? row.Field<string>("FilePath") : "",
                   }).ToList();
                return homelist;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }

        }
        public List<RecentBuyCarousel> GetRecentBuyCarousel()
        {
            List<RecentBuyCarousel> homelist = new List<RecentBuyCarousel>();
            try
            {
                var objectDictionary = new Dictionary<string, object>();
                DataSet ds = accessor.databaseStoredProcedureTransaction(config.GetSection("GetRecent").Value, objectDictionary);
                DataColumnCollection columns = ds.Tables[0].Columns;

                homelist = ds.Tables[0].AsEnumerable().Select(row =>
                   new RecentBuyCarousel
                   {
                       Id = columns.Contains("Id") ? row.Field<int>("Id") : 0,
                       Price = columns.Contains("Price") ? row.Field<string>("Price") : "",
                       Name = columns.Contains("Name") ? row.Field<string>("Name") : "",
                       Description = columns.Contains("Description") ? row.Field<string>("Description") : "",
                       FilePath = columns.Contains("FilePath") ? row.Field<string>("FilePath") : "",
                   }).ToList();
                return homelist;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);

            }
        }
        public async Task<Image> Upload(IFormFile file, Image image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{file.FileName}");
            using (var stream = new FileStream(localFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}" +
          $"://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}" +
          $"/Images/{file.FileName}";
            image.FilePath = urlFilePath;
            await context.Images.AddAsync(image);
            image.FileExtension = Path.GetExtension(localFilePath);
            return image;
        }
    }
}
