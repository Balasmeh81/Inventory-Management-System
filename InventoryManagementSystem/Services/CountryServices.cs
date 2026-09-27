using AutoMapper;
using InventoryManagementSystem.data;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class CountryServices : ICountryServices
    {
        private InventoryContext context;
        private IMapper mapper;

        public CountryServices(IMapper _mapper, InventoryContext _context)
        {
            context = _context;
            mapper = _mapper;
        }

        // Adds a new country to the database.
        public async Task SaveCountryAsync(CountryDTO countryDTO)
        {
            Country newCountry = new Country();
            newCountry = mapper.Map<Country>(countryDTO);
            context.Countries.Add(newCountry);
            await context.SaveChangesAsync();
        }

        // Gets all countries from the database.
        public async Task<List<CountryDTO>> GetAllCountryAsync()
        {
            List<Country> countries =await context.Countries.ToListAsync();
            List<CountryDTO> allCountries = new List<CountryDTO>();
            allCountries = mapper.Map<List<CountryDTO>>(countries);

            return allCountries;
        }

        // Deletes a country by its ID.
        public async Task RemoveCountryAsync(int id)
        {
            Country? country =await context.Countries.FindAsync(id);
            if (country != null)
            {
                context.Countries.Remove(country);
               await context.SaveChangesAsync();
            }
        }

        // Gets a country by its ID.
        public async Task<CountryDTO?> GetCountryByIdAsync(int id)
        {
            Country? country =await context.Countries.FindAsync(id);
            if(country == null)
            {
                return null;
            }
            CountryDTO countryDTO = mapper.Map<CountryDTO>(country);
            return countryDTO;
        }

        // Updates an existing country.
        public async Task UpdateAsync(CountryDTO countryDTO)
        {
            Country country = mapper.Map<Country>(countryDTO);
            context.Countries.Attach(country);
            context.Entry(country).State = EntityState.Modified;
          await  context.SaveChangesAsync();
        }

        // Searches countries by name.
        public async Task<List<CountryDTO>> GetCountryByNameAsync(string name)
        {
            List<Country> country =await context.Countries.Where(c=>c.Name.Contains(name)).ToListAsync();
            List<CountryDTO> allCountry = mapper.Map<List<CountryDTO>>(country);

            return allCountry;
        }
    }
}