using GameStore.Interfaces;
using GameStore.Models;
using GameStore.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IProduct, ProductRepository>();
builder.Services.AddTransient<ICategory, CategoryRepository>();
builder.Services.AddTransient<IOrder, OrderRepository>();

IConfigurationRoot _confString = new ConfigurationBuilder().
    SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

builder.Services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
