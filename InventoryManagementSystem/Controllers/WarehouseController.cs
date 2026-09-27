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

        public async Task<IActionResult> AddWarehouse()
        {
            vmWarehouse vm = new vmWarehouse();
            vm.countries =await countryServices.GetAllCountryAsync();
            vm.cities =await cityServices.GetAllCityAsync();
            ViewData["isEdit"] = false;
            return View("AddWarehouse", vm);
        }

        public async Task<IActionResult> CreateWarehouse(vmWarehouse vm)
        {
            await warehouseSevice.SaveInDbAsync(vm.warehouseDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetWarehouse(string? txtName)
        {
            List<WarehouseDTO> warehouseDTOs;
            if (string.IsNullOrWhiteSpace(txtName))
            {
                warehouseDTOs =await warehouseSevice.GetAllWarehousesAsync();
            }
            else
            {
                warehouseDTOs =await warehouseSevice.GetWarehouseByNameAsync(txtName);
            }

            return View("WarehouseList", warehouseDTOs);
        }

        public async Task<IActionResult> Edit(int WarehouseId)
        {
            WarehouseDTO? warehouseDTO =await warehouseSevice.GetWarehouseByIdAsync(WarehouseId);
            if(warehouseDTO==null)
            {
                return NotFound();
            }
            vmWarehouse vm = new vmWarehouse();

            vm.warehouseDTO = warehouseDTO;

            vm.countries =await countryServices.GetAllCountryAsync();
            vm.cities =await cityServices.GetAllCityAsync();

            ViewData["isEdit"] = true;

            return View("AddWarehouse", vm);
        }

        public async Task<IActionResult> UpdateWarehouse(WarehouseDTO warehouseDTO)
        {
            await warehouseSevice.UpdateFromDbAsync(warehouseDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteWarehouse(int WarehouseId)
        {
           await warehouseSevice.DeleteFromDbAsync(WarehouseId);

            return RedirectToAction("Index");
        }
    }
}