using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public interface ICountryServices
    {
        Task SaveCountryAsync(CountryDTO countryDTO);

        Task<List<CountryDTO>> GetAllCountryAsync();

        Task<CountryDTO?> GetCountryByIdAsync(int id);

        Task RemoveCountryAsync(int id);

        Task UpdateAsync(CountryDTO countryDTO);

        Task<List<CountryDTO>> GetCountryByNameAsync(string name);
    }
}