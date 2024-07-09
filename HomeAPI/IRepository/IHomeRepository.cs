using HomeAPI.DTO;
using HomeAPI.Models;

namespace HomeAPI.IRepository
{
    public interface IHomeRepository
    {
        List<HomeSlider> GetHomeCarousel();
        List<HomeSlider?> HomeCarouselById(int Id);
        Task<HomeSlider> HomeCarouselCreate(HomeSlider model);
        Task<HomeSlider?> HomeCarouselUpdate(int Id, HomeSlider model);
        string HomeCarouselDelete(int Id);
        List<AppliancesCarousel>GetAppliancesCarousel();
        List<AppliancesCarousel?> AppliancesCarouselById(int Id);
        Task<AppliancesCarousel> AppliancesCarouselCreate(AppliancesCarousel model);
        Task<AppliancesCarousel?> AppliancesCarouselUpdate(int Id, AppliancesCarousel model);
        string AppliancesCarouselDelete(int Id);
        List<RecentBuyCarousel> GetRecentBuyCarousel();
        List<RecentBuyCarousel?> GetRecentBuyCarouselById(int Id);
        Task<RecentBuyCarousel> GetRecentBuyCarouselCreate(RecentBuyCarousel model);
        Task<RecentBuyCarousel?> GetRecentBuyCarouselUpdate(int Id, RecentBuyCarousel model);
        string GetRecentBuyCarouselDelete(int Id);
        List<FashionCarousel> GetFashionCarousel();
        List<FashionCarousel?> FashionCarouselById(int Id);
        Task<FashionCarousel> FashionCarouselCreate(FashionCarousel model);
        Task<FashionCarousel?> FashionCarouselUpdate(int Id, FashionCarousel model);
        string FashionCarouselDelete(int Id);
        Task<Image> Upload(IFormFile file, Image image);
    }
}
