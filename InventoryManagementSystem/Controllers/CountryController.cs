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

        public IActionResult CreateCountry(CountryDTO countryDTO)
        {
            countryServices.SaveCountry(countryDTO);
            ViewData["isEdit"] = false;
            return RedirectToAction("AddCountry");
        }

        public ActionResult GetCountry(string? txtName)
        {
            List<CountryDTO> allCountries = new List<CountryDTO>();
            if (string.IsNullOrEmpty(txtName))
            {
                allCountries = countryServices.GetAllCountry();
            }
            else
            {
                allCountries = countryServices.GetCountryByName(txtName);
            }

            return View("CountryList", allCountries);
        }

        public IActionResult DeleteCountry(int CountryId)
        {
            countryServices.RemoveCountry(CountryId);
            return RedirectToAction("GetCountry");
        }

        public IActionResult Edit(int CountryId)
        {
            CountryDTO country = countryServices.GetCountryById(CountryId);
            ViewData["isEdit"] = true;
            return View("AddCountry", country);
        }

        public IActionResult UpdateCountry(CountryDTO countryDTO)
        {
            countryServices.Update(countryDTO);
            return RedirectToAction("GetCountry");
        }
    }
}