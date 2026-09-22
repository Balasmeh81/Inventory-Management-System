using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.data
{
    [Table("Items")]
    [Index(nameof(Warehouse_Id), nameof(Name), IsUnique = true)]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QTY { get; set; }

        public string? SKUCode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MSRPPrice { get; set; }

        [ForeignKey("warehouse")]
        public int Warehouse_Id { get; set; }

        public Warehouse warehouse { get; set; }
    }
}