using AutoMapper;
using InventoryManagementSystem.data;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Services
{
    public class WarehouseSevice : IWarehouseSevice
    {
        private IMapper mapper;
        private InventoryContext context;

        public WarehouseSevice(IMapper _mapper, InventoryContext _context)
        {
            mapper = _mapper;
            context = _context;
        }

        // Adds a new warehouse to the database.
        public async Task SaveInDbAsync(WarehouseDTO warehouseDTO)
        {
            Warehouse newWarehouse = mapper.Map<Warehouse>(warehouseDTO);
            context.Warehouses.Add(newWarehouse);
            await context.SaveChangesAsync();
        }

        // Gets all warehouses with their related city data.
        public async Task<List<WarehouseDTO>> GetAllWarehousesAsync()
        {
            List<Warehouse> warehouses =await context.Warehouses.Include("city").OrderBy(w => w.city.Country_Id).ToListAsync();
            List<WarehouseDTO> warehouseDTOs = mapper.Map<List<WarehouseDTO>>(warehouses);

            return warehouseDTOs;
        }

        // Returns the total number of warehouses.
        public async Task<int> TotalWarehouseAsync()
        {
            int totalWarehouse =await context.Warehouses.CountAsync();
            return totalWarehouse;
        }

        // Gets warehouse summary information for the dashboard.
        public async Task<List<WarehouseOverviewDTO>> GetGeneralInfoAsync()
        {
            var warehouses = await context.Warehouses
        .Select(w => new WarehouseOverviewDTO
        {
            WarehouseName = w.Name,
            CityName = w.city.Name,
            ItemsCount = w.items.Count(),
            UsersCount = w.employees.Count()
        })
        .ToListAsync();

            return warehouses;
        }

        // Searches warehouses by name.
        public async Task<List<WarehouseDTO>> GetWarehouseByNameAsync(string name)
        {
            List<Warehouse> warehouse =await context.Warehouses.Include("city")
                .Where(w => w.Name.Contains(name))
                .ToListAsync();
            List<WarehouseDTO> warehouseDTO = mapper.Map<List<WarehouseDTO>>(warehouse);
            return warehouseDTO;
        }

        // Gets a warehouse by its ID.
        public async Task<WarehouseDTO?> GetWarehouseByIdAsync(int id)
        {
            Warehouse? warehouse =await context.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return null;
            }
            WarehouseDTO warehouseDTO = mapper.Map<WarehouseDTO>(warehouse);
            return warehouseDTO;
        }

        // Updates an existing warehouse in the database.
        public async Task UpdateFromDbAsync(WarehouseDTO warehouseDTO)
        {
            Warehouse warehouse = mapper.Map<Warehouse>(warehouseDTO);

            context.Warehouses.Attach(warehouse);
            context.Entry(warehouse).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        // Deletes a warehouse by its ID.
        public async Task DeleteFromDbAsync(int id)
        {
            Warehouse? warehouse =await context.Warehouses.FindAsync(id);
            if(warehouse == null)
            {
                return;
            }
            context.Warehouses.Remove(warehouse);
            await context.SaveChangesAsync();
        }
    }
}