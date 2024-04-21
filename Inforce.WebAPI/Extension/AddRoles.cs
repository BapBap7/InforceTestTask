using Inforce.DAL.Enums;
using Inforce.DAL.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Inforce.WebAPI.Extension;

public static class AddRoles
{
    public static async Task ApplyMigrations(this WebApplication app)
    {
        try
        {
            var context = app.Services.GetRequiredService<MyDbContext>();
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}