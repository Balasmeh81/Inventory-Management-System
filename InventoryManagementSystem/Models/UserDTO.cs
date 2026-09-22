namespace InventoryManagementSystem.Models
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int Warehouse_Id { get; set; }
        public WarehouseDTO warehouse { get; set; }
    }
}