using System.Reflection;
using be_aspnet_demo.models.user;
using Microsoft.EntityFrameworkCore;

namespace be_aspnet_demo.utils;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration) => _configuration = configuration;


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}