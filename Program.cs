using SchoolManagementApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Data;
using SchoolManagementApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SchoolManagementAppContextConnection") ?? throw new InvalidOperationException("Connection string 'SchoolManagementAppContextConnection' not found.");

builder.Services.AddDbContext<SchoolManagementAppContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<SchoolManagementAppUser> (options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SchoolManagementAppContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SchoolManagementDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "schools",
    pattern: "{controller=Schools}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "departments",
    pattern: "{controller=Departments}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "classes",
    pattern: "{controller=Classes}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "users",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "roles",
    pattern: "{controller=Roles}/{action=Index}");

app.MapRazorPages();

app.Run();
