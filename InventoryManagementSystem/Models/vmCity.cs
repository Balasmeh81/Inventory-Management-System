using InventoryManagementSystem.data;

namespace InventoryManagementSystem.Models
{
    public class vmCity
    {
        public CityDTO cityDTO { get; set; }
        public List<CountryDTO> countryDTOs { get; set; }
    }
}