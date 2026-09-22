using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class WarehouseController : Controller
    {
        private ICountryServices countryServices;
        private ICityService cityServices;
        private IWarehouseSevice warehouseSevice;

        public WarehouseController(ICityService _cityServices, ICountryServices _countryServices, IWarehouseSevice _wearehouseSevice)
        {
            warehouseSevice = _wearehouseSevice;
            countryServices = _countryServices;
            cityServices = _cityServices;
        }

        public IActionResult Index()
        {
            List<WarehouseDTO> warehouseDTOs = new List<WarehouseDTO>();

            return View("WarehouseList", warehouseDTOs);
        }

        public IActionResult AddWarehouse()
        {
            vmWarehouse vm = new vmWarehouse();
            vm.countries = countryServices.GetAllCountry();
            vm.cities = cityServices.GetAllCity();
            ViewData["isEdit"] = false;
            return View("AddWarehouse", vm);
        }

        public IActionResult CreateWarehouse(vmWarehouse vm)
        {
            warehouseSevice.SaveInDb(vm.warehouseDTO);
            return RedirectToAction("Index");
        }

        public IActionResult GetWarehouse(string? txtName)
        {
            List<WarehouseDTO> warehouseDTOs;
            if (string.IsNullOrWhiteSpace(txtName))
            {
                warehouseDTOs = warehouseSevice.GetAllWarehouses();
            }
            else
            {
                warehouseDTOs = warehouseSevice.GetWarehouseByName(txtName);
            }

            return View("WarehouseList", warehouseDTOs);
        }

        public IActionResult Edit(int WarehouseId)
        {
            WarehouseDTO warehouseDTO = warehouseSevice.GetWarehouseById(WarehouseId);
            vmWarehouse vm = new vmWarehouse();
            vm.warehouseDTO = warehouseDTO;
            vm.countries = countryServices.GetAllCountry();
            vm.cities = cityServices.GetAllCity();
            ViewData["isEdit"] = true;
            return View("AddWarehouse", vm);
        }

        public IActionResult UpdateWarehouse(WarehouseDTO warehouseDTO)
        {
            warehouseSevice.UpdateFromDb(warehouseDTO);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteWarehouse(int WarehouseId)
        {
            warehouseSevice.DeleteFromDb(WarehouseId);

            return RedirectToAction("Index");
        }
    }
}