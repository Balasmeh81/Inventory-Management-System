using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class SignUp
    {
        [Required(ErrorMessage = "Please Enetr The Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enetr The Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enetr The Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enetr The Confirm Password")]
        [Compare("Password")]
        public String ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enetr The Role")]
        public string RoleName { get; set; }

        public int? WarehouseId { get; set; }

        public WarehouseDTO? warehouse { get; set; }
    }
}