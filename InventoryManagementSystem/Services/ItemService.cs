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

        public void SaveToDb(ItemDTO item)
        {
            Item newItem = mapper.Map<Item>(item);
            context.Items.Add(newItem);
            context.SaveChanges();
        }

        public List<ItemDTO> GetAllItems()
        {
            List<Item> items = context.Items.Include("warehouse").ToList();
            List<ItemDTO> allItems = mapper.Map<List<ItemDTO>>(items);
            return allItems;
        }

        public void UpdateFromDb(ItemDTO itemDTO)
        {
            Item item = mapper.Map<Item>(itemDTO);
            context.Items.Attach(item);
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public ItemDTO GetItemById(int id)
        {
            Item item = context.Items.Find(id);
            ItemDTO itemDTO = mapper.Map<ItemDTO>(item);
            return itemDTO;
        }

        public void DeleteFromDb(int id)
        {
            Item item = context.Items.Find(id);
            context.Items.Remove(item);
            context.SaveChanges();
        }

        public int TotalItem()
        {
            return context.Items.Count();
        }
    }
}