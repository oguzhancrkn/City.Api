using City.Api.Core;
using City.Api.Core.Dtos.City;
using City.Api.Services.CityService;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
            var data = await _cityService.GetAllCity();
            return Ok(data);
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
        [HttpPut]

        public async Task<ActionResult<ServiceResponse<GetCity>>> UpdateCity(UpdateCity updateCity)
        {
            var response = await _cityService.UpdateCity(updateCity);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCity>>>> DeleteCity(int id)
        {
            var response = await _cityService.DeleteCity(id);
            if (response.Data == null)
            { return NotFound(response); }
            return Ok(response);
        }




    }
}
