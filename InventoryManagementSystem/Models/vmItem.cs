namespace InventoryManagementSystem.Models
{
    public class vmItem
    {
        public ItemDTO itemDTO { get; set; }
        public List<WarehouseDTO> warehouseDTOs { get; set; }
    }
}