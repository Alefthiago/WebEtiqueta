using Microsoft.EntityFrameworkCore;
using WebEtiqueta.Services;
using WebEtiqueta.Models;
using WebEtiqueta.Repositorys;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<EtiquetaService>();
builder.Services.AddScoped<FilialService>();
builder.Services.AddScoped<MatrizService>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<EtiquetaRepository>();
builder.Services.AddScoped<FilialRepository>();
builder.Services.AddScoped<MatrizRepository>();
builder.Services.AddScoped<UsuarioRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
    pattern: "{controller=Etiqueta}/{action=Index}/{id?}");

app.Run();