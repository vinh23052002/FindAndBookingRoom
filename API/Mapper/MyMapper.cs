using API.Dtos.District;
using API.Dtos.Image;
using API.Dtos.Province;
using API.Dtos.Ward;
using API.Models;
using AutoMapper;

namespace API.Mapper
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<Province, ProvinceResponse>();
            CreateMap<ProvinceRequest, Province>();

            CreateMap<District, DistrictResponse>();
            CreateMap<DistrictRequest, District>();

            CreateMap<Ward, WardResponse>();
            CreateMap<WardRequest, Ward>();

            CreateMap<Image, ImageResponse>();
            CreateMap<ImageRequest, Image>();

        }
    }
}
