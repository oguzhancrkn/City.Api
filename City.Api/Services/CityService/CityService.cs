using AutoMapper;
using City.Api.Core;
using City.Api.Core.Dtos.City;
using City.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace City.Api.Services.CityService
{
    public class CityService : ICityService
    {
        //private static List<CityEntity> cityEnties = new List<CityEntity>
        //{
        //    new CityEntity(),
        //    new CityEntity{Id=1 , Name = "Trabzon" }
        //};
        private IMapper _mapper;
        private readonly DataContext _context;


        public CityService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<ServiceResponse<List<GetCity>>> AddCity(AddCity newcity)
        {
            var serviceResponse = new ServiceResponse<List<GetCity>>();
            CityEntity city = _mapper.Map<CityEntity>(newcity);
            //city.Id = cityEnties.Max(x => x.Id) + 1;
            //cityEnties.Add(city);
            //cityEnties.Add(_mapper.Map<CityEntity>(newcity));
            _context.CityEntities.Add(city);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.CityEntities
                .Select(x => _mapper.Map<GetCity>(x)).ToListAsync(); 
            //cityEnties.Select(x => _mapper.Map<GetCity>(x)).ToList();
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCity>>> GetAllCity()
        {
            //var test = _context.CityEntities.ToList();  

            var response = new ServiceResponse<List<GetCity>>();
            var dbCityEnties = await _context.CityEntities.ToListAsync();
            response.Data = dbCityEnties.Select(x => _mapper.Map<GetCity>(x)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCity>> GetAllCityById(int id)
        {

            var serviceResponse = new ServiceResponse<GetCity>();
            var dbcity = await _context.CityEntities.FirstOrDefaultAsync(x => x.Id == id);
            serviceResponse.Data = _mapper.Map<GetCity>(dbcity);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCity>> UpdateCity(UpdateCity updatecity)
        {
            ServiceResponse<GetCity> serviceResponse = new ServiceResponse<GetCity>();

            try
            {
                var city = await _context.CityEntities.FirstOrDefaultAsync(x => x.Id == updatecity.Id);
                city.Name = updatecity.Name;
                city.Populasyon = updatecity.Populasyon;
                city.Class = updatecity.Class;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCity>(city);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCity>>> DeleteCity(int id)
        {
            ServiceResponse<List<GetCity>> serviceresponse = new ServiceResponse<List<GetCity>>();
            try
            {
                CityEntity city = await _context.CityEntities.FirstOrDefaultAsync(x => x.Id == id);
                _context.CityEntities.Remove(city);
                await _context.SaveChangesAsync();
                serviceresponse.Data = _context.CityEntities.Select(x => _mapper.Map<GetCity>(x)).ToList();

            }
            catch (Exception ex)
            {
                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
            }
            return serviceresponse;
        }

    }
}
