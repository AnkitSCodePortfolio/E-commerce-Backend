using AutoMapper;
using Azure.Core;
using HomeAPI.DBContext;
using HomeAPI.DTO;
using HomeAPI.IRepository;
using HomeAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IHomeRepository repo;
        private readonly ILogger<IHomeRepository> logger;
        private readonly HomeDBContext context;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(IHomeRepository repo,ILogger<IHomeRepository> logger,HomeDBContext context,IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.repo = repo;
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

       [HttpGet("Appliances")]
        public async Task<IActionResult> GetAllAppliances() 
        {
            try
            {
                var data =  repo.GetAppliancesCarousel();
                return Ok(mapper.Map<List<ApplianceResponseDTO>>(data));
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
        [HttpGet("AppliancesFind/{Id}")]
        public async Task<IActionResult> GetAppliancesById([FromRoute] int Id)
        {
            try
            {
                var data = repo.AppliancesCarouselById(Id);
                if (data == null)
                {
                    NotFound();
                }
                return Ok(mapper.Map<ApplianceResponseDTO>(data));
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
        [HttpPost("AppliancesCreate")]
        public async Task<IActionResult> CreateAppliances([FromForm] ApplianceRequestDTO model)
        {
            try
            {
                var studentEntity = mapper.Map<AppliancesCarousel>(model);
                var data = await repo.AppliancesCarouselCreate(studentEntity);
                var studentresponse = new ApplianceResponseDTO
                {
                    Id = studentEntity.Id,
                    Name = studentEntity.Name,
                    Price = studentEntity.Price,
                    Description = studentEntity.Description,
                    Filepath = studentEntity.FilePath,
                };
                return Ok(studentresponse);


            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }

        [HttpPut("AppliancesUpdate/{Id}")]
        public async Task<IActionResult> UpdateAppliances([FromRoute] int Id, [FromForm] ApplianceRequestDTO model)
        {
            try
            {
                var student = new AppliancesCarousel
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Image = model.Image,
                    
                };
                var data = await repo.AppliancesCarouselUpdate(Id, student);
                if (data == null)
                {
                   return NotFound();
                }
                else
                {
                    var response = new ApplianceResponseDTO
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Price = data.Price,
                        Description = data.Description,
                        Filepath = data.FilePath
                    };
                    return Ok(response);    
                }

            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
        [HttpDelete("AppliancesDelete/{Id}")]
        public async  Task<IActionResult> DeleteAppliances([FromRoute] int Id)
        {
            try
            {
                var data =  repo.AppliancesCarouselDelete(Id);
                if (data == null)
                {
                    return NotFound();
                }
                var user = mapper.Map<AppliancesCarousel>(data);
                return Ok(user);
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
        [HttpGet("FashionGet")]
        public async Task<IActionResult> GetAllFashion()
        {
            try
            {
                var data =  repo.GetFashionCarousel();
                return Ok(mapper.Map<List<FashionResponseDTO>>(data));
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }


        [HttpGet("FashionFind/{Id}")]
        public async Task<IActionResult> GetFashionById([FromRoute] int Id)
        {
            try
            {
                var data =  repo.FashionCarouselById(Id);
                if(data == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<FashionResponseDTO>(data));
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }   
        }
        [HttpPost("FashionCreate")]
        public async Task<IActionResult> CreateFashion([FromForm] FashionRequestDTO model)
        {
            try
            {
           
                var studentEntity = mapper.Map<FashionCarousel>(model);
                var data = await repo.FashionCarouselCreate(studentEntity);
                var studentresponse = new FashionResponseDTO
                {
                    Id = studentEntity.Id,
                    Name = studentEntity.Name,
                    Price = studentEntity.Price,
                    Description = studentEntity.Description,
                    Image = studentEntity.FilePath,
                };
                return Ok(studentresponse);
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
        [HttpPut("FashionUpdate/{Id}")]
        public async Task<IActionResult> UpdateFashion([FromRoute] int Id, [FromForm] FashionRequestDTO model)
        {
            try
            {
                var student = new FashionCarousel
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Image = model.Image,
                };
                 var request = await repo.FashionCarouselUpdate(Id, student);
                if (request == null)
                {
                    return NotFound();
                }
                else
                {
                    var response = new FashionResponseDTO
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Price = request.Price,
                        Description = request.Description,
                        Filepath = request.FilePath
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
    
        [HttpDelete("FashionDelete/{Id}")]
        public async Task<IActionResult> DeleteFashion([FromRoute] int Id)
        {
            try
            {
                var data =  repo.FashionCarouselDelete(Id);
                if (data == null)
                {
                    return NotFound();
                }
                var user = mapper.Map<FashionCarousel>(data);
                return Ok(user);
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
        [HttpGet("HomeGet")]
        public async Task<IActionResult> GetAllHome()
        {
            try
            {
                var data =  repo.GetHomeCarousel();
                return Ok(mapper.Map<List<HomeResponseDTO>>(data));
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }


        [HttpGet("HomeFind /{Id}")]
        public async Task<IActionResult> GetHomeById([FromRoute] int Id)
        {
            try
            {
                var data =  repo.HomeCarouselById(Id);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<HomeResponseDTO>(data));
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
       

        [HttpPost("HomeCreate")]
        public async Task<IActionResult> CreateHome([FromForm] HomeRequestDTO model)
        {
            try
            {
                
                var studentEntity = mapper.Map<HomeSlider>(model);
                var data = await repo.HomeCarouselCreate(studentEntity);
                var recenthome = new HomeResponseDTO
                {
                    Id = studentEntity.Id,
                    Name = studentEntity.Name,
                    Price = studentEntity.Price,
                    Description = studentEntity.Description,
                    Image = studentEntity.FilePath,
                };
                return Ok(recenthome);
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }

         [HttpPut("HomeUpdate/{Id}")]
         public async Task<IActionResult> UpdateHome([FromRoute] int Id, [FromForm] HomeRequestDTO model)
         {
             try
             {
                var student = new HomeSlider
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Image = model.Image,
                };
                
                 var request = await repo.HomeCarouselUpdate(Id, student);
                 if (request == null)
                 {
                      return NotFound();
                 }
                else
                {
                    var response = new HomeResponseDTO
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Price = request.Price,
                        Description = request.Description,
                        Filepath = request.FilePath
                    };
                    return Ok(response);
                }
            }
             catch (Exception ex)
             {
                 string msg = "Database Error:";
                 msg += ex.Message;
                 throw new Exception(msg);
             }
         }
        [HttpDelete("HomeDelete/{Id}")]
        public async Task<IActionResult> DeleteHome([FromRoute] int Id)
        {
            try
            {
                var data = repo.HomeCarouselDelete(Id);
                if (data == null)
                {
                    return NotFound();
                }
                var user = mapper.Map<HomeSlider>(data);
                return Ok(user);
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
        [HttpGet("RecentGet")]
        public async Task<IActionResult> GetAllRecentBuy()
        {
            try
            {
                var data = repo.GetRecentBuyCarousel();
                return Ok(mapper.Map<List<RecentResponseDTO>>(data));
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }


        [HttpGet("RecentFind/{Id}")]
        public async Task<IActionResult> GetRecentBuyById([FromRoute] int Id)
        {
            try
            {
                var data =  repo.GetRecentBuyCarouselById(Id);
                if(data == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<RecentResponseDTO>(data));
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
        [HttpPost("RecentCreate")]
        public async Task<IActionResult> CreateRecentHome([FromForm] RecentRequestDTO model)
        {
            try
            {

                var studentEntity = mapper.Map<RecentBuyCarousel>(model);
                var data = await repo.GetRecentBuyCarouselCreate(studentEntity);
                var recenthome = new RecentResponseDTO
                {
                    Id = studentEntity.Id,
                    Name = studentEntity.Name,
                    Price = studentEntity.Price,
                    Description = studentEntity.Description,
                    Image = studentEntity.FilePath,
                };
                return Ok(recenthome);
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }

         [HttpPut("RecentUpdate/{Id}")]
          public async Task<IActionResult> UpdateRecentBuy([FromRoute] int Id, [FromForm] RecentRequestDTO model)
          {
              try
              {
                var student = new RecentBuyCarousel
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Image = model.Image,
                };
                var  request = await repo.GetRecentBuyCarouselUpdate(Id, student);
                  if (request == null)
                  {
                     return NotFound();
                  }
                else
                {
                    var response = new RecentResponseDTO
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Price = request.Price,
                        Description = request.Description,
                        Filepath = request.FilePath
                    };
                    return Ok(response);
                }

            }
              catch (Exception ex)
              {
                  string msg = "Database Error:";
                  msg += ex.Message;
                  throw new Exception(msg);
              }
          }
        [HttpDelete("RecentDelete/{Id}")]
        public async Task<IActionResult> DeleteRecentBuy([FromRoute] int Id)
        {
            try
            {
                var data = repo.GetRecentBuyCarouselDelete(Id);
                if(data == null)
                {
                    return NotFound();
                }
                var user =mapper.Map<RecentBuyCarousel>(data);
                return Ok(user);
            }
            catch (Exception ex)
            {
                string msg = "Database Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
       
    }
}
