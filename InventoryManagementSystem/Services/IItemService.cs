using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public interface IItemService
    {
        void SaveToDb(ItemDTO item);

        List<ItemDTO> GetAllItems();

        void UpdateFromDb(ItemDTO itemDTO);

        ItemDTO GetItemById(int id);

        void DeleteFromDb(int id);

        int TotalItem();
    }
}