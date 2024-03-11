using Microsoft.EntityFrameworkCore;
using be_aspnet_demo.models.paging;
using be_aspnet_demo.models.user.form;
using be_aspnet_demo.utils;

namespace be_aspnet_demo.models.user;

public class UserRepository(AppDbContext context) : BaseRepository(context)
{
    public async Task<Paging<User>> ListAsync(UserQuery query)
    {
        IQueryable<User> queryable = _context.Users.AsNoTracking();

        if (!String.IsNullOrEmpty(query.Name))
        {
            queryable = queryable.Where(u => EF.Functions.Like(u.Name, $"%{query.Name}%"));
        }

        int total = await queryable.CountAsync();

        List<User> users = await queryable
            .OrderByDescending(u => u.CreatedAt)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();

        return new Paging<User>
        {
            Items = users,
            Total = total,
            CurrentPage = query.Page,
            CurrentPageSize = users.Count
        };
    }

    public Task<User?> FindById(long id)
    {
        return _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
    }

    public void AddAsync(User user)
    {
        _context.Users.Add(user);
    }

    public void Update(User user)
    {   
        _context.Users.Update(user);
    }
    
    public void Delete(User existingUser)
    {
        _context.Users.Remove(existingUser);
    }
}