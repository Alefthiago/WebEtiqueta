using Microsoft.EntityFrameworkCore;
using WebEtiqueta.Services;
using WebEtiqueta.Models;
using WebEtiqueta.Repositorys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<HomeService>();
builder.Services.AddScoped<EtiquetaService>();

builder.Services.AddScoped<EtiquetaRepository>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1); // Expiração da sessão em 1 dia
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Adiciona o DbContext e configura o uso do Npgsql
builder.Services.AddDbContext<Contexto>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();