using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore; // DbContext eklemeyi unutmayın
using PersonelGirisKontrolSistemi.Models;
using PersonelGirisKontrolSistemi.Controllers;
// DbContext sınıfınıza ait namespace'i ekleyin
using PersonelGirisKontrolSistemi.Services;
using YourNamespace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DbContext'i ekleyin
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//AD bağlantısı için sağlıyorum.
builder.Services.AddScoped<IUserService, ActiveDirectoryUserService>();

var app = builder.Build();

// Middleware yapılandırmaları
// Örneğin, kimlik doğrulama ve yetkilendirme middleware'leri
app.UseAuthentication();
app.UseAuthorization();

// Diğer middleware ve endpoint yapılandırmaları
app.MapControllers();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//db bağlantısı için

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
