using City.Api.Core;
using Microsoft.AspNetCore.Mvc;

namespace City.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private static List<CityEntity> cityEnties = new List<CityEntity>
        {
            new CityEntity(),
            new CityEntity{Id=1 , Name = "Trabzon" }
        };

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<CityEntity>> Get()
        {
            return Ok(cityEnties);
        }
        [HttpGet("{id}")]
        public ActionResult<CityEntity> GetSingle(int id)
        {
            var city = cityEnties.Find(x => x.Id == id);
            return Ok(city);

        }
        [HttpPost]
        public ActionResult<List<CityEntity>> AddCity(CityEntity newcity)
        {
            cityEnties.Add(newcity);
            return Ok(cityEnties);
        }
        [HttpDelete]

    }
}
