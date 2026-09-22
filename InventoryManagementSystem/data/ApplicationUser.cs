using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        [ForeignKey("warehouse")]
        public int? Warehouse_Id { get; set; }

        public Warehouse? warehouse { get; set; }
    }
}