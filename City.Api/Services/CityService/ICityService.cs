using City.Api.Core;
using City.Api.Core.Dtos.City;
using System.Net.Security;

namespace City.Api.Services.CityService
{
    public interface ICityService
    {
        Task<ServiceResponse<List<GetCity>>> GetAllCity();
        Task<ServiceResponse<GetCity>> GetAllCityById(int id);
        
        Task<ServiceResponse<List<GetCity>>> AddCity(AddCity newcity);

    }
}

