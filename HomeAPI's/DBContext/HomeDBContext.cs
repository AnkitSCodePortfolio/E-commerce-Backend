using HomeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.DBContext
{
    public class HomeDBContext : DbContext
    {
        public HomeDBContext(DbContextOptions<HomeDBContext> options) : base(options)
        {
        }
        public DbSet<HomeSlider> HomeSlider { get; set; }
        public DbSet<AppliancesCarousel> AppSlider { get; set; }
        public DbSet<RecentBuyCarousel> RecentSlider { get; set; }
        public DbSet<FashionCarousel> FashionSlider { get; set; }
    }
}
