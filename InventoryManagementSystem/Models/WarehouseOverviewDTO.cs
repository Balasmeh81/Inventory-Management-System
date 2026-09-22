namespace InventoryManagementSystem.Models
{
    public class WarehouseOverviewDTO
    {
        public string WarehouseName { get; set; }
        public string CityName { get; set; }
        public int ItemsCount { get; set; }
        public int UsersCount { get; set; }
    }
}