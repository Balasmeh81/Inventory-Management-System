using AutoMapper;
using InventoryManagementSystem.data;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    [AutoMap(typeof(Item), ReverseMap = true)]
    public class ItemDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter The Item Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter The Quantity Of Item")]
        public int QTY { get; set; }

        public string? SKUCode { get; set; }

        [Required(ErrorMessage = "Please Enter The CostPrice Of Item")]
        public decimal CostPrice { get; set; }

        [Required(ErrorMessage = "Please Enter The MSRPPrice Of Item")]
        public decimal MSRPPrice { get; set; }

        [Required(ErrorMessage = "Please Enter The Warehouse")]
        public int warehouse_Id { get; set; }

        public WarehouseDTO warehouse { get; set; }
    }
}