// using Microsoft.EntityFrameworkCore;

// namespace be_aspnet_demo.models.user
// {
//
//     public class UserDAO : DbContext
//     {
//         private readonly string _connectionString = "Server=localhost; Port=3309; User ID=root; Password=example; Database=test";
//         
//         public DbSet<User> Users { get; set; }
//         
//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
//         }
//     }
// }