using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.data
{
    [Table("Cities")]
    [Index(nameof(Country_Id), nameof(Name), IsUnique = true)]
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("country")]
        public int Country_Id { get; set; }

        public Country country { get; set; }

        public List<Warehouse> Warehouses { get; set; }
    }
}