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

        public void SaveCountry(CountryDTO countryDTO)
        {
            Country newCountry = new Country();
            newCountry = mapper.Map<Country>(countryDTO);
            context.Countries.Add(newCountry);
            context.SaveChanges();
        }

        public List<CountryDTO> GetAllCountry()
        {
            List<Country> countries = context.Countries.ToList();
            List<CountryDTO> allCountries = new List<CountryDTO>();
            allCountries = mapper.Map<List<CountryDTO>>(countries);

            return allCountries;
        }

        public void RemoveCountry(int id)
        {
            Country? country = context.Countries.Find(id);
            if (country != null)
            {
                context.Countries.Remove(country);
                context.SaveChanges();
            }
        }

        public CountryDTO GetCountryById(int id)
        {
            Country country = context.Countries.Find(id);
            CountryDTO countryDTO = mapper.Map<CountryDTO>(country);
            return countryDTO;
        }

        public void Update(CountryDTO countryDTO)
        {
            Country country = mapper.Map<Country>(countryDTO);
            context.Countries.Attach(country);
            context.Entry(country).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<CountryDTO> GetCountryByName(string name)
        {
            List<Country> country = context.Countries.Where(n => n.Name == name).ToList();
            List<CountryDTO> allCountry = mapper.Map<List<CountryDTO>>(country);

            return allCountry;
        }
    }
}