using AutoMapper;
using HomeAPI.DTO;
using HomeAPI.Models;

namespace HomeAPI.Mapper
{
    public class AutoMapperProfile : Profile
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public AutoMapperProfile()
        {
            CreateMap<AppliancesCarousel, ApplianceResponseDTO>().ReverseMap();
            CreateMap<ApplianceRequestDTO, AppliancesCarousel>().ReverseMap();
            CreateMap<ApplianceUpdateDTO, AppliancesCarousel>().ReverseMap();
            CreateMap<FashionCarousel, FashionResponseDTO>().ReverseMap();
            CreateMap<FashionRequestDTO, FashionCarousel>().ReverseMap();
            CreateMap<FashionUpdateDTO, FashionCarousel>().ReverseMap();
            CreateMap<HomeSlider, HomeResponseDTO>().ReverseMap();
            CreateMap<HomeRequestDTO, HomeSlider>().ReverseMap();
            CreateMap<HomeUpdateDTO, HomeSlider>().ReverseMap();
            CreateMap<RecentBuyCarousel, RecentResponseDTO>().ReverseMap();
            CreateMap<RecentRequestDTO, RecentBuyCarousel>().ReverseMap();
            CreateMap<RecentUpdateDTO, RecentBuyCarousel>().ReverseMap();
        }

    }
}
