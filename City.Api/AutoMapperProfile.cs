using AutoMapper;
using City.Api.Core;
using City.Api.Core.Dtos.City;

namespace City.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CityEntity, GetCity>();
            CreateMap<AddCity, CityEntity>();

        }
    }
}
