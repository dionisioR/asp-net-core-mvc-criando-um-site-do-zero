using LancheMac_SSMS.Context;
using LancheMac_SSMS.Models;
using LancheMac_SSMS.Repositories;
using LancheMac_SSMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// Configurar a string de conex�o
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar o DbContext e configurar o SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
);

// Registrando os servi�os de reposit�rios : Inje��o de depend�ncia
builder.Services.AddTransient<ILancheRepository, LancheRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

// definindo o servi�o para acessar os recursos do HttpContextAcessor
// addSingleton - quer dizer que ele vai durar durante todo tempo de vida da aplica��o
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));


// Configurando Session
builder.Services.AddMemoryCache();
builder.Services.AddSession();

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Ativando a session
app.UseSession();  // <<<<<
//------------------------------------

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
