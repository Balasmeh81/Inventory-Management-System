using InventoryManagementSystem.data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService accountService;
        private IWarehouseSevice warehouseSevice;

        public AccountController(IAccountService _accountService, IWarehouseSevice _warehouseSevice)
        {
            accountService = _accountService;
            warehouseSevice = _warehouseSevice;
        }

        public IActionResult SignUp()
        {
            List<WarehouseDTO> warehouseDTOs = warehouseSevice.GetAllWarehouses();
            vmSignUp vm = new vmSignUp();
            vm.warehouseDTOs = warehouseDTOs;
            List<RoleModel> allroles = accountService.GetAllRole();
            vm.Roles = allroles;
            return View("SignUp", vm);
        }

        public async Task<IActionResult> CreateAccount(vmSignUp vm)
        {
            await accountService.CreateAccount(vm.signUp);

            return RedirectToAction("SignUp");
        }

        public IActionResult Signin()
        {
            ViewData["Invalid"] = false;
            return View();
        }

        public async Task<ActionResult> LogIn(LogInModel logInModel)
        {
            var result = await accountService.LogIn(logInModel);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewData["Invalid"] = true;
                return View("Signin", logInModel);
            }
        }

        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        public IActionResult LogOut()
        {
            accountService.LogOut();

            return RedirectToAction("Signin");
        }

        // --- Role Services ---

        public IActionResult AddRole()
        {
            ViewData["isEdit"] = false;
            return View("AddRole");
        }

        public async Task<IActionResult> CreateRole(RoleModel roleModel)
        {
            var ressult = await accountService.AddRoleInDb(roleModel);
            ViewData["isEdit"] = false;
            return RedirectToAction("AddRole");
        }

        public IActionResult RoleList()
        {
            List<RoleModel> allRoles = accountService.GetAllRole();

            return View("RoleList", allRoles);
        }

        public IActionResult EditRole(string RoleId)
        {
            RoleModel roleModel = accountService.GetRoleById(RoleId);
            ViewData["isEdit"] = true;

            return View("AddRole", roleModel);
        }

        public async Task<IActionResult> UpdateRole(RoleModel roleModel)
        {
            await accountService.UpdateRoleFromDb(roleModel);

            return RedirectToAction("RoleList");
        }

        public async Task<IActionResult> DeleteRole(string RoleId)
        {
            await accountService.DeleteRoleFromDb(RoleId);
            return RedirectToAction("RoleList");
        }
    }
}