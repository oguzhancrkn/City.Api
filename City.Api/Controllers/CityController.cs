using City.Api.Core;
using City.Api.Core.Dtos.City;
using City.Api.Services.CityService;
using Microsoft.AspNetCore.Mvc;

namespace City.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {   
       private readonly ICityService _cityService;
       public CityController(ICityService cityService)         
       {
            _cityService = cityService;
        
       }

        [HttpGet]
        //[Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCity>>>> Get()
        {
            return Ok(_cityService.GetAllCity());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCity>>> GetSingle(int id)
        {
        
            return Ok(_cityService.GetAllCityById(id));

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCity>>>> AddCity(AddCity newcity)
        {
           
            return Ok(_cityService.AddCity(newcity));
        }


    }
}
