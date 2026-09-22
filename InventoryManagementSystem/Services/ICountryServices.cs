using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public interface ICountryServices
    {
        void SaveCountry(CountryDTO countryDTO);

        List<CountryDTO> GetAllCountry();

        CountryDTO GetCountryById(int id);

        void RemoveCountry(int id);

        void Update(CountryDTO countryDTO);

        List<CountryDTO> GetCountryByName(string name);
    }
}