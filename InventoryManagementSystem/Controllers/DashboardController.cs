using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        private IAccountService accountService;
        private IWarehouseSevice wearehouseSevice;
        private IItemService itemService;

        public DashboardController(IAccountService _accountService
            , IWarehouseSevice _wearehouseSevice
            , IItemService _itemService)
        {
            accountService = _accountService;
            wearehouseSevice = _wearehouseSevice;
            itemService = _itemService;
        }

        public async Task<IActionResult> Index()
        {
            DahboardModel model = new DahboardModel();
            model.TotalUser = await accountService.TotalUser();
            model.TotalWarehouse =await wearehouseSevice.TotalWarehouseAsync();
            model.TotalItem = await itemService.TotalItemAsync();
            model.OverviewDTOs = await wearehouseSevice.GetGeneralInfoAsync();

            return View("Dashboard", model);
        }
    }
}