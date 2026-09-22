using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.data
{
    [Table("Warehouses")]
    [Index(nameof(City_Id), nameof(Name), IsUnique = true)]
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        [ForeignKey("city")]
        public int City_Id { get; set; }

        public City city { get; set; }

        public List<Item> items { get; set; }
        public List<ApplicationUser> employees { get; set; }
    }
}