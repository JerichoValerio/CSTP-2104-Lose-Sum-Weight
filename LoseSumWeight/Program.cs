using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LoseSumWeight.Models;
using LoseSumWeight.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LoseSumWeightContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoseSumWeightContext") ?? throw new InvalidOperationException("Connection string 'LoseSumWeightContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "main",
    pattern: "Main/{controller=Products}/{action=Index}/{id?}");


app.Run();
