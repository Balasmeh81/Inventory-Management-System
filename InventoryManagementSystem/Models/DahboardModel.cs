using InventoryManagementSystem.data;

namespace InventoryManagementSystem.Models
{
    public class DahboardModel
    {
        public int TotalUser { get; set; }
        public int TotalWarehouse { get; set; }
        public int TotalItem { get; set; }
        public List<WarehouseOverviewDTO> OverviewDTOs { get; set; }
    }
}