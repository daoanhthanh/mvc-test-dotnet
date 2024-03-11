using be_aspnet_demo.models.exceptions;
using be_aspnet_demo.models.idGenerator;
using be_aspnet_demo.models.paging;
using be_aspnet_demo.models.user.dto;
using be_aspnet_demo.models.user.form;

namespace be_aspnet_demo.models.user;

public class UserService
{
    private UserRepository _userRepo;
    private UnitOfWork _commit; 

    public UserService(UserRepository userRepo, UnitOfWork u)
    {
        _userRepo = userRepo;
        _commit = u;
    }

    public Task<Paging<User>> GetAllAsync(UserQuery userquery)
    {
        return _userRepo.ListAsync(userquery);
    }

    public Task<User?> FindById(long id)
    {
        return _userRepo.FindById(id);
    }

    public Task<bool> AddAsync(UserDTO user)
    {
        User u = new()
        {
            Id = SnowFlakeId.NextId(),
            Name = user.Name,
            Email = user.Email,
            Phone = user.Phone,
            Address = user.Address,
            DoB = user.DoB
        };
        
        _userRepo.AddAsync(u);
        return _commit.SaveChangesAsync()
            .ContinueWith(r => r.Result > 0);
    }

    public async Task<bool> Update(long userId, User user)
    {
        var maybeUser = await _userRepo.FindById(userId);
        
        if (maybeUser == null)
        {
            throw new EntityNotFound($"{userId}");
        }
        
        user.Id = userId;

        _userRepo.Update(user);
        
        return await _commit.SaveChangesAsync()
            .ContinueWith(r => r.Result > 0);
    }
    
    public async Task<bool> Delete(long userId)
    {
        var maybeUser = await _userRepo.FindById(userId);
        
        if (maybeUser == null)
        {
            throw new EntityNotFound($"{userId}");
        }
        
        _userRepo.Delete(maybeUser);
        
        return await _commit.SaveChangesAsync()
            .ContinueWith(r => r.Result > 0);
    }
}