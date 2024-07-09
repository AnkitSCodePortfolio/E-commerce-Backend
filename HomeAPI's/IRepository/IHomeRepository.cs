using HomeAPI.Models;

namespace HomeAPI.IRepository
{
    public interface IHomeRepository
    {
        Task<List<HomeSlider>> GetHomeCarousel();
        Task<HomeSlider?> HomeCarouselById(int Id);
        Task<HomeSlider> HomeCarouselCreate(HomeSlider model);
        Task<HomeSlider?> HomeCarouselUpdate(int Id, HomeSlider model);
        Task<HomeSlider?> HomeCarouselDelete(int Id);
        Task<List<AppliancesCarousel>> GetAppliancesCarousel();
        Task<AppliancesCarousel?> AppliancesCarouselById(int Id);
        Task<AppliancesCarousel> AppliancesCarouselCreate(AppliancesCarousel model);
        Task<AppliancesCarousel?> AppliancesCarouselUpdate(int Id, AppliancesCarousel model);
        Task<AppliancesCarousel?> AppliancesCarouselDelete(int Id);
        Task<List<RecentBuyCarousel>> GetRecentBuyCarousel();
        Task<RecentBuyCarousel?> GetRecentBuyCarouselById(int Id);
        Task<RecentBuyCarousel> GetRecentBuyCarouselCreate(RecentBuyCarousel model);
        Task<RecentBuyCarousel?> GetRecentBuyCarouselUpdate(int Id, RecentBuyCarousel model);
        Task<RecentBuyCarousel?> GetRecentBuyCarouselDelete(int Id);
        Task<List<FashionCarousel>> GetFashionCarousel();
        Task<FashionCarousel?> FashionCarouselById(int Id);
        Task<FashionCarousel> FashionCarouselCreate(FashionCarousel model);
        Task<FashionCarousel?> FashionCarouselUpdate(int Id, FashionCarousel model);
        Task<FashionCarousel?> FashionCarouselDelete(int Id);
    }
}
