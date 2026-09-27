using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public interface ICityService
    {
        Task SaveCityAsync(CityDTO cityDTO);

        Task<List<CityDTO>> GetAllCityAsync();

        Task<CityDTO?> GetCityByIdAsync(int id);

        Task<List<CityDTO>> GetCityByNameAsync(string name);

        Task UpdateFromDbAsync(CityDTO cityDTO);

        Task RemoveFromDbAsync(int Id);
    }
}