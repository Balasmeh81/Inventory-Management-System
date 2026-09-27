using AutoMapper;
using InventoryManagementSystem.data;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class ItemService : IItemService
    {
        private IMapper mapper;
        private InventoryContext context;

        public ItemService(InventoryContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task SaveToDbAsync(ItemDTO item)
        {
            Item newItem = mapper.Map<Item>(item);
            context.Items.Add(newItem);
           await context.SaveChangesAsync();
        }

        public async Task<List<ItemDTO>> GetAllItemsAsync(CancellationToken cancellationToken)
        {
            List<Item> items = await context.Items.Include("warehouse").ToListAsync(cancellationToken);
            List<ItemDTO> allItems = mapper.Map<List<ItemDTO>>(items);
            return allItems;
        }

        public async Task UpdateFromDbAsync(ItemDTO itemDTO)
        {
            Item item = mapper.Map<Item>(itemDTO);
            context.Items.Attach(item);
            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<ItemDTO?> GetItemByIdAsync(int id)
        {
            Item? item = await context.Items.FindAsync(id);
            if (item == null)
            {
                return null;
            }
            ItemDTO itemDTO = mapper.Map<ItemDTO>(item);
            return itemDTO;
        }

        public async Task DeleteFromDbAsync(int id)
        {
            Item? item = await context.Items.FindAsync(id);
            if (item == null)
            {
                return;
            }

            context.Items.Remove(item);
           await context.SaveChangesAsync();
        }

        public async Task<int> TotalItemAsync()
        {
            return await context.Items.CountAsync();
        }
    }
}