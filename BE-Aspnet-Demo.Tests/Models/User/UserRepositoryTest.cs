using be_aspnet_demo.models.idGenerator;
using be_aspnet_demo.models.user;
using be_aspnet_demo.utils;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace BE_Aspnet_Demo.Tests.Models.User;

[TestSubject(typeof(UserRepository))]
public class UserRepositoryTest
{
    private DbContextOptions<AppDbContext> TestContext => new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase("InMemoryDatabase")
        .Options;
    

    private List<be_aspnet_demo.models.user.User> OriginalUser(List<long> userIdGen)
    {
        return new()
        {
            new()
            {
                Id = userIdGen[0],
                Name = "test1",
                Email = "test1@gmail.com",
                Phone = "123456789",
                Address = "test1",
                DoB = new DateOnly(2021, 1, 1),
                CreatedAt = default,
                UpdatedAt = default
            },
            new()
            {
                Id = userIdGen[1],
                Name = "test2",
                Email = "test2",
                Phone = "123456789",
                Address = "test2",
                DoB = new DateOnly(2021, 1, 1),
                CreatedAt = default,
                UpdatedAt = default
            }
        };
    }

    [Fact]
    public async void Repo_Should_Save_And_Find_Successfully()
    {
        using (var context = new AppDbContext(TestContext))
        {
            var repo = new UserRepository(context);

            var newIds = new List<long>
            {
                SnowFlakeId.NextId(),
                SnowFlakeId.NextId()
            };
            
            var users = OriginalUser(newIds);
            repo.Add(users[0]);
            repo.Add(users[1]);
            context.SaveChanges();

            var user1 = await repo.FindById(newIds[0]);
            var user2 = await repo.FindById(newIds[1]);
            
            Assert.Equal(users[0].Name, user1!.Name);
            Assert.Equal(users[1].Email, user2!.Email);
        }
    }
    
    // [Fact]
    public async void Repo_Should_Update_Successfully()
    {
        
        var newIds = new List<long>
        {
            12345678,
            98765432
        };
            
        var users = OriginalUser(newIds);
        
        using (var context = new AppDbContext(TestContext))
        {
            var repo = new UserRepository(context);
            repo.Add(users[0]);
            await context.SaveChangesAsync();


            var user = await repo.FindById(newIds[0]);
            user!.Name = "test3";
            repo.Update(user);
            await context.SaveChangesAsync();

            var updatedUser = await repo.FindById(newIds[0]);
            Assert.Equal("test3", updatedUser!.Name);
            
        }
    }
}