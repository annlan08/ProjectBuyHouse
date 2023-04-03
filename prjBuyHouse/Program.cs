using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using prjBuyHouse.Models;
using prjBuyHouse.Repository;
using prjBuyHouse.Repository.Interfaces;
using prjBuyHouse.Services;
using prjBuyHouse.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region ³]©wDB
builder.Services.AddDbContext<HouseContext>(option =>
                                            option.UseSqlServer(builder.Configuration.GetConnectionString("HouseContext")));
var optionsBuilder = new DbContextOptionsBuilder<HouseContext>();
optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("HouseContext"));
var options = optionsBuilder.Options;
#endregion

builder.Services.AddSingleton<IHouseRepository>(_=>new HouseRepository(new HouseContext(options)));
builder.Services.AddSingleton<IHouseService, HouseService>();

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
