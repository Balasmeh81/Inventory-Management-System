using AutoMapper;
using InventoryManagementSystem.data;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    [AutoMap(typeof(City), ReverseMap = true)]
    public class CityDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter The City Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter The Country Name")]
        public int Country_Id { get; set; }

        public CountryDTO country { get; set; }
    }
}