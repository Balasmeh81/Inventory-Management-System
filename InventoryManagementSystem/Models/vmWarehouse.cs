namespace InventoryManagementSystem.Models
{
    public class vmWarehouse
    {
        public WarehouseDTO warehouseDTO { get; set; }
        public List<CityDTO> cities { get; set; }
        public List<CountryDTO> countries { get; set; }
    }
}