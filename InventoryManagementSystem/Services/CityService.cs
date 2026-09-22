using AutoMapper;
using InventoryManagementSystem.data;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class CityService : ICityService
    {
        private IMapper mapper;
        private InventoryContext context;

        public CityService(IMapper _mapper, InventoryContext _context)
        {
            mapper = _mapper;
            context = _context;
        }

        public void SaveCity(CityDTO cityDTO)
        {
            City newCity = mapper.Map<City>(cityDTO);
            context.Cities.Add(newCity);
            context.SaveChanges();
        }

        public List<CityDTO> GetAllCity()
        {
            List<City> cities = context.Cities
                .OrderBy(c => c.Country_Id)
                .ToList();
            List<CityDTO> allCities = mapper.Map<List<CityDTO>>(cities);
            return allCities;
        }

        public CityDTO GetCityById(int id)
        {
            City city = context.Cities.Find(id);
            CityDTO cityDTO = mapper.Map<CityDTO>(city);
            return cityDTO;
        }

        public List<CityDTO> GetCityByName(string name)
        {
            List<City> cities = context.Cities.Where(n => n.Name == name).ToList();
            List<CityDTO> cityDTOs = mapper.Map<List<CityDTO>>(cities);
            return cityDTOs;
        }

        public void RemoveFromDb(int Id)
        {
            //context.Cities.FirstOrDefault();
            City city = context.Cities.Find(Id);
            context.Cities.Remove(city);
            context.SaveChanges();
        }

        public void UpdateFromDb(CityDTO cityDTO)
        {
            City city = mapper.Map<City>(cityDTO);

            context.Cities.Attach(city);
            context.Entry(city).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}