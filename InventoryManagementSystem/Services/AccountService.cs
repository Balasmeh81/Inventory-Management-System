using AutoMapper;
using InventoryManagementSystem.data;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private InventoryContext context;
        private IMapper mapper;
        private SignInManager<ApplicationUser> signInManager;

        public AccountService(UserManager<ApplicationUser> _userManager
              , RoleManager<IdentityRole> _roleManager
              , InventoryContext _context
              , IMapper _mapper
              , SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            context = _context;
            mapper = _mapper;
            signInManager = _signInManager;
        }

        public async Task<IdentityResult> CreateAccount(SignUp signUp)
        {
            ApplicationUser newUser = new ApplicationUser();
            newUser.UserName = signUp.Email;
            newUser.Email = signUp.Email;
            newUser.Name = signUp.Name;
            newUser.Warehouse_Id = signUp.WarehouseId;

            var CreationResult = await userManager.CreateAsync(newUser, signUp.Password);

            if (CreationResult.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(newUser, signUp.RoleName);
                if (roleResult.Succeeded == false)
                {
                    userManager.DeleteAsync(newUser);
                }
            }
            return CreationResult;
        }

        public async Task<SignInResult> LogIn(LogInModel logInModel)
        {
            var result = await signInManager.PasswordSignInAsync(logInModel.UserName, logInModel.Password, false, false);
            return result;
        }

        public async Task<int> TotalUser()
        {
            int totalUser = await userManager.Users.CountAsync();
            return totalUser;
        }

        public async Task LogOut()
        {
            await signInManager.SignOutAsync();
        }

        // ---- Role Services ----

        public async Task<IdentityResult> AddRoleInDb(RoleModel role)
        {
            IdentityRole newRole = new IdentityRole();
            newRole.Name = role.Name;
            var result = await roleManager.CreateAsync(newRole);
            return result;
        }

        public List<RoleModel> GetAllRole()
        {
            List<IdentityRole> allRoles = roleManager.Roles.ToList();
            List<RoleModel> roleModels = mapper.Map<List<RoleModel>>(allRoles);
            return roleModels;
        }

        public RoleModel GetRoleById(string id)
        {
            IdentityRole role = roleManager.Roles.Where(r => r.Id == id).FirstOrDefault();
            RoleModel roleModel = mapper.Map<RoleModel>(role);
            return roleModel;
        }

        public async Task<IdentityResult> UpdateRoleFromDb(RoleModel roleModel)
        {
            IdentityRole role = await roleManager.FindByIdAsync(roleModel.Id);

            role.Name = roleModel.Name;
            var result = await roleManager.UpdateAsync(role);
            return result;
        }

        public async Task<IdentityResult> DeleteRoleFromDb(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            var result = await roleManager.DeleteAsync(role);
            return result;
        }
    }
}