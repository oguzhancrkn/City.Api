using AutoMapper;
using City.Api.Core;
using City.Api.Core.Dtos.City;
using System.Linq;

namespace City.Api.Services.CityService
{
    public class CityService : ICityService
    {
        private static List<CityEntity> cityEnties = new List<CityEntity>
        {
            new CityEntity(),
            new CityEntity{Id=1 , Name = "Trabzon" }
        };
        private IMapper _mapper;

        public CityService(IMapper mapper) 
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCity>>> AddCity(AddCity newcity)
        {
            var serviceResponse = new ServiceResponse<List<GetCity>>();
            cityEnties.Add(_mapper.Map<CityEntity>(newcity));
            serviceResponse.Data = cityEnties.Select(x=>_mapper.Map<GetCity>(x)).Tolist();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCity>>> GetAllCity()
        {
            var serviceResponse = new ServiceResponse<List<GetCity>> { Data = cityEnties.Select(x => _mapper.Map<GetCity>(x)).Tolist()};
            return serviceResponse;
           
        }

        public async Task<ServiceResponse<GetCity>> GetAllCityById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCity>();
            var city = cityEnties.FirstOrDefault(x => x.Id == id);
            serviceResponse.Data = _mapper.Map<GetCity>(city);
            return serviceResponse;
        }

    }
}
