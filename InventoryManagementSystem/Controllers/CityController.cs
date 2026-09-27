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

        public async Task<IActionResult> AddCity()
        {
            vmCity vm = new vmCity();
            ViewData["isEdit"] = false;
            vm.countryDTOs =await countryServices.GetAllCountryAsync();
            return View("AddCity", vm);
        }

        public async Task<IActionResult> CreateCity(vmCity vm)
        {
          await  cityService.SaveCityAsync(vm.cityDTO);

            return RedirectToAction("CityList");
        }

        public IActionResult CityList()
        {
            List<CityDTO> cityDTOs = new List<CityDTO>();
            return View("CityList", cityDTOs);
        }

        public async Task<IActionResult> GetCity(string? txtName)
        {
            List<CityDTO> allCities = new List<CityDTO>();

            if (txtName == null)
            {
                allCities =await cityService.GetAllCityAsync();
            }
            else
            {
                allCities =await cityService.GetCityByNameAsync(txtName);
            }

            return View("CityList", allCities);
        }

        public async Task<IActionResult> Delete(int CityId)
        {
           await cityService.RemoveFromDbAsync(CityId);

            return RedirectToAction("CityList");
        }

        public async Task<IActionResult> Edit(int CityId)
        {
            vmCity vm = new vmCity();
            vm.cityDTO =await cityService.GetCityByIdAsync(CityId);
            if (vm.cityDTO == null)
            {
                return NotFound();
            }

            ViewData["isEdit"] = true;
            vm.countryDTOs =await countryServices.GetAllCountryAsync();
            return View("AddCity", vm);
        }

        public async Task<IActionResult> UpdateCity(vmCity vm)
        {
           await cityService.UpdateFromDbAsync(vm.cityDTO);
            return RedirectToAction("CityList");
        }
    }
}