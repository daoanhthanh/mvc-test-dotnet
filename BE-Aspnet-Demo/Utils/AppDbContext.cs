using System.Reflection;
using be_aspnet_demo.models.user;
using Microsoft.EntityFrameworkCore;

namespace be_aspnet_demo.utils;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    public DbSet<User> Users { get; set; }
}