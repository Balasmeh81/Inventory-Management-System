using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public interface IItemService
    {
        Task SaveToDbAsync(ItemDTO item);

        Task<List<ItemDTO>> GetAllItemsAsync(CancellationToken cancellationToken);

        Task UpdateFromDbAsync(ItemDTO itemDTO);

        Task<ItemDTO?> GetItemByIdAsync(int id);

        Task DeleteFromDbAsync(int id);

        Task<int> TotalItemAsync();
    }
}