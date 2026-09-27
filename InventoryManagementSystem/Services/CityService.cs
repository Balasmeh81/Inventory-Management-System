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

        public async Task SaveCityAsync(CityDTO cityDTO)
        {
            City newCity = mapper.Map<City>(cityDTO);
            context.Cities.Add(newCity);
            await context.SaveChangesAsync();
        }

        public async Task<List<CityDTO>> GetAllCityAsync()
        {
            List<City> cities =await context.Cities
                .OrderBy(c => c.Country_Id)
                .ToListAsync();
            List<CityDTO> allCities = mapper.Map<List<CityDTO>>(cities);
            return allCities;
        }

        public async Task<CityDTO?> GetCityByIdAsync(int id)
        {
            City? city =await context.Cities.FindAsync(id);
            if (city == null)
            {
                return null;
            }
            CityDTO cityDTO = mapper.Map<CityDTO>(city);
            return cityDTO;
        }

        public async Task<List<CityDTO>> GetCityByNameAsync(string name)
        {
            List<City> cities = await context.Cities.Where(c => c.Name.Contains(name)).ToListAsync();
            List<CityDTO> cityDTOs = mapper.Map<List<CityDTO>>(cities);
            return cityDTOs;
        }

        public async Task RemoveFromDbAsync(int Id)
        {
            //context.Cities.FirstOrDefault();
            City? city =await context.Cities.FindAsync(Id);
            if (city == null)
            {
                return;
            }
            context.Cities.Remove(city);
           await context.SaveChangesAsync();
        }

        public async Task UpdateFromDbAsync(CityDTO cityDTO)
        {
            City city = mapper.Map<City>(cityDTO);

            context.Cities.Attach(city);
            context.Entry(city).State = EntityState.Modified;
           await context.SaveChangesAsync();
        }
    }
}