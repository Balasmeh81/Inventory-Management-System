using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private ICountryServices countryServices;

        public CountryController(ICountryServices _countryServices)
        {
            countryServices = _countryServices;
        }

        public IActionResult CountryList()
        {
            List<CountryDTO> allCountries = new List<CountryDTO>();
            return View("CountryList", allCountries);
        }

        public IActionResult AddCountry()
        {
            ViewData["isEdit"] = false;
            return View("AddCountry");
        }

        public async Task<IActionResult> CreateCountry(CountryDTO countryDTO)
        {
            await countryServices.SaveCountryAsync(countryDTO);
            ViewData["isEdit"] = false;
            return RedirectToAction("AddCountry");
        }

        public async Task<IActionResult> GetCountry(string? txtName)
        {
            List<CountryDTO> allCountries = new List<CountryDTO>();
            if (string.IsNullOrEmpty(txtName))
            {
                allCountries =await countryServices.GetAllCountryAsync();
            }
            else
            {
                allCountries =await countryServices.GetCountryByNameAsync(txtName);
            }

            return View("CountryList", allCountries);
        }

        public async Task<IActionResult> DeleteCountry(int CountryId)
        {
           await countryServices.RemoveCountryAsync(CountryId);
            return RedirectToAction("GetCountry");
        }

        public async Task<IActionResult> Edit(int CountryId)
        {
            CountryDTO? country =await countryServices.GetCountryByIdAsync(CountryId);
            if(country==null)
            {
                return NotFound();
            }
            ViewData["isEdit"] = true;
            return View("AddCountry", country);
        }

        public async Task<IActionResult> UpdateCountry(CountryDTO countryDTO)
        {
           await countryServices.UpdateAsync(countryDTO);
            return RedirectToAction("GetCountry");
        }
    }
}