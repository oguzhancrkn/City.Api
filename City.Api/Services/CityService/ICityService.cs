using City.Api.Core;
using System.Net.Security;

namespace City.Api.Services.CityService
{
    public interface ICityService
    {
        Task<ServiceResponse<List<CityEntity>>> GetAllCity();
        Task<ServiceResponse<CityEntity>> GetAllCityById(int id);
        
        Task<ServiceResponse<List<CityEntity>>> AddCity(CityEntity newcity);

    }
}

