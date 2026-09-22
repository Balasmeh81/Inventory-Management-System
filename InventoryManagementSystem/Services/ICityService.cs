using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public interface ICityService
    {
        void SaveCity(CityDTO cityDTO);

        List<CityDTO> GetAllCity();

        CityDTO GetCityById(int id);

        List<CityDTO> GetCityByName(string name);

        void UpdateFromDb(CityDTO cityDTO);

        void RemoveFromDb(int Id);
    }
}