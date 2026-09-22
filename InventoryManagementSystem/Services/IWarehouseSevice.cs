using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public interface IWarehouseSevice
    {
        void SaveInDb(WarehouseDTO warehouseDTO);

        List<WarehouseDTO> GetAllWarehouses();

        List<WarehouseDTO> GetWarehouseByName(string name);

        WarehouseDTO GetWarehouseById(int id);

        void UpdateFromDb(WarehouseDTO warehouseDTO);

        void DeleteFromDb(int id);

        int TotalWarehouse();

        Task<List<WarehouseOverviewDTO>> GetGeneralInfo();
    }
}