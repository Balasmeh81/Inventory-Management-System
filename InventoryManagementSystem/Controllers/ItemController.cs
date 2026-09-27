using InventoryManagementSystem.data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Authorize(Roles = "Employee,Admin")]
    public class ItemController : Controller
    {
        private IWarehouseSevice warehouseService;
        private IItemService itemService;

        public ItemController(IWarehouseSevice _warehouseService, IItemService _itemService)
        {
            warehouseService = _warehouseService;
            itemService = _itemService;
        }

        public IActionResult Index()
        {
            List<ItemDTO> itemDTOs = new List<ItemDTO>();
            return View("ItemList", itemDTOs);
        }

        public async Task<IActionResult> AddItem()
        {
            vmItem vm = new vmItem();
            vm.warehouseDTOs =await warehouseService.GetAllWarehousesAsync();
            ViewData["isEdit"] = false;
            return View("AddItem", vm);
        }

        public async Task<IActionResult> CreateItem(vmItem vm)
        {
           await itemService.SaveToDbAsync(vm.itemDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetItem(CancellationToken cancellationToken)
        {
            List<ItemDTO> itemDTOs = await itemService.GetAllItemsAsync(cancellationToken);
            return View("ItemList", itemDTOs);
        }

        public async Task<IActionResult> Edit(int itemid)
        {
            ItemDTO? itemDTO = await itemService.GetItemByIdAsync(itemid);
            if (itemDTO == null)
            {
                return NotFound();
            }

            vmItem vm = new vmItem();
            vm.itemDTO = itemDTO;
            vm.warehouseDTOs =await warehouseService.GetAllWarehousesAsync();
            ViewData["isEdit"] = true;
            return View("AddItem", vm);
        }

        public async Task<IActionResult> UpdateItem(vmItem vm)
        {
           await itemService.UpdateFromDbAsync(vm.itemDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int itemid)
        {
           await itemService.DeleteFromDbAsync(itemid);

            return RedirectToAction("Index");
        }
    }
}