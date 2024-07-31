using City.Api.Core;

namespace City.Api.Services.CityService
{
    public class CityService : ICityService
    {
        private static List<CityEntity> cityEnties = new List<CityEntity>
        {
            new CityEntity(),
            new CityEntity{Id=1 , Name = "Trabzon" }
        };
        public async Task<ServiceResponse<List<CityEntity>>> AddCity(CityEntity newcity)
        {
            var serviceResponse = new ServiceResponse<List<CityEntity>>();
            cityEnties.Add(newcity);
            serviceResponse.Data = cityEnties;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CityEntity>>> GetAllCity()
        {
            var serviceResponse = new ServiceResponse<List<CityEntity>> { Data = cityEnties };
            return serviceResponse;
        }

        public async Task<ServiceResponse<CityEntity>> GetAllCityById(int id)
        {
            var serviceResponse = new ServiceResponse<CityEntity>();
            var city = cityEnties.FirstOrDefault(x => x.Id == id);
            serviceResponse.Data = city;
            return serviceResponse;
        }

    }
}
