using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.data
{
    public class LogInModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}