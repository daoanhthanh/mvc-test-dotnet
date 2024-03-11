using be_aspnet_demo.utils;

namespace be_aspnet_demo.models;

public class UnitOfWork(AppDbContext context)
{
    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}