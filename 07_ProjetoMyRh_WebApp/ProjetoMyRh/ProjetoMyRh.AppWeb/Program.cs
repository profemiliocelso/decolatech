using Microsoft.EntityFrameworkCore;
using ProjetoMyRh.AppWeb.Models.Contexts;
using ProjetoMyRh.AppWeb.Models.Startup;
using ProjetoMyRh.AppWeb.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<MyRhContext>(options => 
    options.UseSqlServer(config.GetConnectionString("MyRhConnection")));

// Habilitando o serviço AreasService para injeção de dependência
builder.Services.AddScoped<AreasService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

var scope = app.Services.CreateScope();
var provider = scope.ServiceProvider;
var context = provider.GetRequiredService<MyRhContext>();

// Sincronizando o contexto com o banco de dados
DbInitializer.Initialize(context);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
