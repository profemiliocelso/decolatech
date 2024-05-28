using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoMyRh.API.Auth;
using ProjetoMyRh.API.Models.Contexts;
using ProjetoMyRh.API.Models.Startup;
using ProjetoMyRh.API.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;
// Add services to the container.

builder.Services.AddDbContext<MyRhContext>(options => 
    options.UseSqlServer(config.GetConnectionString("MyRhConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("IdentityConnection")));

// Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = config["JWT:ValidAudience"],
        ValidIssuer = config["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]!))
    };
});


builder.Services.AddScoped<AreasService>();
builder.Services.AddScoped<CandidatosService>();
builder.Services.AddScoped<InscricoesService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(policy =>
    policy.AddDefaultPolicy(p =>
        p.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();


var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<MyRhContext>(); //neste momento, MyRhContext é instanciado

// sincronizando com o banco de dados
DbInitializer.Initialize(context);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseAuthentication(); //

app.UseAuthorization();

app.MapControllers();

app.Run();
