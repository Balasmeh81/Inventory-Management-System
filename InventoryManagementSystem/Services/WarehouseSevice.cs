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

        public void SaveInDb(WarehouseDTO warehouseDTO)
        {
            Warehouse newWarehouse = mapper.Map<Warehouse>(warehouseDTO);
            context.Warehouses.Add(newWarehouse);
            context.SaveChanges();
        }

        public List<WarehouseDTO> GetAllWarehouses()
        {
            List<Warehouse> warehouses = context.Warehouses.Include("city").OrderBy(w => w.city.Country_Id).ToList();
            List<WarehouseDTO> warehouseDTOs = mapper.Map<List<WarehouseDTO>>(warehouses);

            return warehouseDTOs;
        }

        public int TotalWarehouse()
        {
            int totalWarehouse = context.Warehouses.Count();
            return totalWarehouse;
        }

        public async Task<List<WarehouseOverviewDTO>> GetGeneralInfo()
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

        public List<WarehouseDTO> GetWarehouseByName(string name)
        {
            List<Warehouse> warehouse = context.Warehouses.Include("city")
                .Where(w => w.Name.Contains(name))
                .ToList();
            List<WarehouseDTO> warehouseDTO = mapper.Map<List<WarehouseDTO>>(warehouse);
            return warehouseDTO;
        }

        public WarehouseDTO GetWarehouseById(int id)
        {
            Warehouse warehouse = context.Warehouses.Find(id);
            WarehouseDTO warehouseDTO = mapper.Map<WarehouseDTO>(warehouse);
            return warehouseDTO;
        }

        public void UpdateFromDb(WarehouseDTO warehouseDTO)
        {
            Warehouse warehouse = mapper.Map<Warehouse>(warehouseDTO);

            context.Warehouses.Attach(warehouse);
            context.Entry(warehouse).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteFromDb(int id)
        {
            Warehouse warehouse = context.Warehouses.Find(id);
            context.Warehouses.Remove(warehouse);
            context.SaveChanges();
        }
    }
}