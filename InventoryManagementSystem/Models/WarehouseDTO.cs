using AutoMapper;
using InventoryManagementSystem.data;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    [AutoMap(typeof(Warehouse), ReverseMap = true)]
    public class WarehouseDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter The Warehouse Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter The Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter The City Name")]
        public int City_Id { get; set; }

        public CityDTO city { get; set; }
    }
}