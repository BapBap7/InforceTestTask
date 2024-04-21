using Inforce.DAL.Entities.Shortener;
using Inforce.DAL.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inforce.DAL.Persistence;

public class MyDbContext : IdentityDbContext<User>
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=PC;Database=Inforce;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    
    public override DbSet<User> Users { get; set; }
    
    public DbSet<ShortenedUrl> ShortenedUrls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShortenedUrl>(builder =>
        {
            builder.Property(s => s.Code).HasMaxLength(7);
            
            builder.HasIndex(s => s.Code).IsUnique();
        });
    }

}