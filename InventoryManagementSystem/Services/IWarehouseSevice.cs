using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public interface IWarehouseSevice
    {
        Task SaveInDbAsync(WarehouseDTO warehouseDTO);

        Task<List<WarehouseDTO>> GetAllWarehousesAsync();

        Task<List<WarehouseDTO>> GetWarehouseByNameAsync(string name);

        Task<WarehouseDTO?> GetWarehouseByIdAsync(int id);

        Task UpdateFromDbAsync(WarehouseDTO warehouseDTO);

        Task DeleteFromDbAsync(int id);

        Task<int> TotalWarehouseAsync();

        Task<List<WarehouseOverviewDTO>> GetGeneralInfoAsync();
    }
}