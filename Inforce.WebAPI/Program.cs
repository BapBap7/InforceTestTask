using Inforce.BLL.Interfaces.Authentication;
using Inforce.BLL.Services.Authentication;
using Inforce.DAL.Enums;
using Inforce.DAL.Persistence;
using Inforce.DAL.Repositories.Interfaces.Base;
using Inforce.DAL.Repositories.Realizations.Base;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Inforce.WebAPI.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddAutoMapper(currentAssemblies);
builder.Services.AddMediatR(currentAssemblies);

// Add MVC services for controllers
builder.Services.AddControllers(); // This line is necessary


builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<Inforce.DAL.Entities.Users.User, IdentityRole>()
    .AddEntityFrameworkStores<MyDbContext>();

builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

app.UseCors(opt => { opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000"); });

// Configure the HTTP request pipeline.
app.UseForwardedHeaders();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await EnsureRolesAsync(roleManager);
}

async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
{
    // Check if the roles exist and create them if they do not already exist
    if (!await roleManager.RoleExistsAsync(nameof(UserRole.Admin)))
    {
        await roleManager.CreateAsync(new IdentityRole(nameof(UserRole.Admin)));
    }
    if (!await roleManager.RoleExistsAsync(nameof(UserRole.User)))
    {
        await roleManager.CreateAsync(new IdentityRole(nameof(UserRole.User)));
    }
}

await app.ApplyMigrations();

app.UseHttpsRedirection();


app.Run();

public partial class Program
{
    
}