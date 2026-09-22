using AutoMapper;
using InventoryManagementSystem.data;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    [AutoMap(typeof(Country), ReverseMap = true)]
    public class CountryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter The Country Name")]
        public string Name { get; set; }
    }
}