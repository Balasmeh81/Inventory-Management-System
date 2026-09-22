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

        public IActionResult AddItem()
        {
            vmItem vm = new vmItem();
            vm.warehouseDTOs = warehouseService.GetAllWarehouses();
            ViewData["isEdit"] = false;
            return View("AddItem", vm);
        }

        public IActionResult CreateItem(vmItem vm)
        {
            itemService.SaveToDb(vm.itemDTO);
            return RedirectToAction("Index");
        }

        public IActionResult GetItem()
        {
            List<ItemDTO> itemDTOs = itemService.GetAllItems();
            return View("ItemList", itemDTOs);
        }

        public IActionResult Edit(int itemid)
        {
            ItemDTO itemDTO = itemService.GetItemById(itemid);
            vmItem vm = new vmItem();
            vm.itemDTO = itemDTO;
            vm.warehouseDTOs = warehouseService.GetAllWarehouses();
            ViewData["isEdit"] = true;
            return View("AddItem", vm);
        }

        public IActionResult UpdateItem(vmItem vm)
        {
            itemService.UpdateFromDb(vm.itemDTO);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int itemid)
        {
            itemService.DeleteFromDb(itemid);

            return RedirectToAction("Index");
        }
    }
}