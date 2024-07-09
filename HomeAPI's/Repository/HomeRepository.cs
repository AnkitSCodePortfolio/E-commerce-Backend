using HomeAPI.DBContext;
using HomeAPI.IRepository;
using HomeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly HomeDBContext context;

        public HomeRepository(HomeDBContext context)
        {
            this.context = context;
        }

        public async Task<AppliancesCarousel?> AppliancesCarouselById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppliancesCarousel> AppliancesCarouselCreate(AppliancesCarousel model)
        {
            throw new NotImplementedException();
        }

        public async Task<AppliancesCarousel?> AppliancesCarouselDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppliancesCarousel?> AppliancesCarouselUpdate(int Id, AppliancesCarousel model)
        {
            throw new NotImplementedException();
        }

        public async Task<FashionCarousel?> FashionCarouselById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<FashionCarousel> FashionCarouselCreate(FashionCarousel model)
        {
            throw new NotImplementedException();
        }

        public async  Task<FashionCarousel?> FashionCarouselDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<FashionCarousel?> FashionCarouselUpdate(int Id, FashionCarousel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppliancesCarousel>> GetAppliancesCarousel()
        {
            return await context.AppSlider.ToListAsync();
        }

        public async Task<List<FashionCarousel>> GetFashionCarousel()
        {
            return await context.FashionSlider.ToListAsync();
        }

        public async Task<List<HomeSlider>> GetHomeCarousel()
        {
            return await context.HomeSlider.ToListAsync();
        }

        public async Task<List<RecentBuyCarousel>> GetRecentBuyCarousel()
        {
            return await context.RecentSlider.ToListAsync();
        }

        public async Task<RecentBuyCarousel?> GetRecentBuyCarouselById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<RecentBuyCarousel> GetRecentBuyCarouselCreate(RecentBuyCarousel model)
        {
            throw new NotImplementedException();
        }

        public async Task<RecentBuyCarousel?> GetRecentBuyCarouselDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<RecentBuyCarousel?> GetRecentBuyCarouselUpdate(int Id, RecentBuyCarousel model)
        {
            throw new NotImplementedException();
        }

        public async Task<HomeSlider?> HomeCarouselById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<HomeSlider> HomeCarouselCreate(HomeSlider model)
        {
            throw new NotImplementedException();
        }

        public async Task<HomeSlider?> HomeCarouselDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<HomeSlider?> HomeCarouselUpdate(int Id, HomeSlider model)
        {
            throw new NotImplementedException();
        }
    }
}
