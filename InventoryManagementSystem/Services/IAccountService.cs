using InventoryManagementSystem.data;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccount(SignUp signUp);

        Task<SignInResult> LogIn(LogInModel logInModel);

        Task LogOut();

        Task<int> TotalUser();

        // ---- Role Servoces ----
        Task<IdentityResult> AddRoleInDb(RoleModel role);

        List<RoleModel> GetAllRole();

        RoleModel GetRoleById(string id);

        Task<IdentityResult> UpdateRoleFromDb(RoleModel roleModel);

        Task<IdentityResult> DeleteRoleFromDb(string id);
    }
}