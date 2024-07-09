using AutoMapper;
using HomeAPI.DBContext;
using HomeAPI.IRepository;
using Microsoft.AspNetCore.Mvc;

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

        public HomeController(IHomeRepository repo,ILogger<IHomeRepository> logger,HomeDBContext context,IMapper mapper)
        {
            this.repo = repo;
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

       /* [HttpPost]
        public */
        
    }
}
