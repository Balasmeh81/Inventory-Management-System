namespace InventoryManagementSystem.Models
{
    public class vmSignUp
    {
        public SignUp signUp { get; set; }
        public List<RoleModel> Roles { get; set; }
        public List<WarehouseDTO> warehouseDTOs { get; set; }
    }
}