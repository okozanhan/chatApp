
using Dal;
using Dal.Context;
using Dal.Entity;

namespace Business;

public class UserService : IUserService
{
    private readonly ChatDbContext _chatDbContext;

    public UserService(ChatDbContext chatDbContext)
    {
        _chatDbContext = chatDbContext;
    }

    public Task<int> AddUser(AddUserDto addUserDto)
    {
        throw new NotImplementedException();
    }

    public Task<GetUserDto> getUserById(int id)
    {
        throw new NotImplementedException();
    }
}
