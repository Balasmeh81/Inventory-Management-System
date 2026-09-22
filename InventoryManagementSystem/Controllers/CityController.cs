using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private ICountryServices countryServices;
        private ICityService cityService;

        public CityController(ICountryServices _countryServices, ICityService _cityService)
        {
            countryServices = _countryServices;
            cityService = _cityService;
        }

        public IActionResult AddCity()
        {
            vmCity vm = new vmCity();
            ViewData["isEdit"] = false;
            vm.countryDTOs = countryServices.GetAllCountry().ToList();
            return View("AddCity", vm);
        }

        public IActionResult CreateCity(vmCity vm)
        {
            cityService.SaveCity(vm.cityDTO);

            return RedirectToAction("CityList");
        }

        public IActionResult CityList()
        {
            List<CityDTO> cityDTOs = new List<CityDTO>();
            return View("CityList", cityDTOs);
        }

        public IActionResult GetCity(string? txtName)
        {
            List<CityDTO> allCities = new List<CityDTO>();

            if (txtName == null)
            {
                allCities = cityService.GetAllCity();
            }
            else
            {
                allCities = cityService.GetCityByName(txtName);
            }

            return View("CityList", allCities);
        }

        public IActionResult Delete(int CityId)
        {
            cityService.RemoveFromDb(CityId);

            return RedirectToAction("CityList");
        }

        public IActionResult Edit(int CityId)
        {
            vmCity vm = new vmCity();
            vm.cityDTO = cityService.GetCityById(CityId);

            ViewData["isEdit"] = true;
            vm.countryDTOs = countryServices.GetAllCountry().ToList();
            return View("AddCity", vm);
        }

        public IActionResult UpdateCity(vmCity vm)
        {
            cityService.UpdateFromDb(vm.cityDTO);
            return RedirectToAction("CityList");
        }
    }
}