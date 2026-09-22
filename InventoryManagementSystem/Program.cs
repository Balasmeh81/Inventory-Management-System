using InventoryManagementSystem.data;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICountryServices, CountryServices>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IWarehouseSevice, WarehouseSevice>();
builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddDbContext<InventoryContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Identity Classes
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<InventoryContext>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Account/Signin";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Signin}/{id?}")
    .WithStaticAssets();

app.Run();