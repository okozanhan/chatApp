
using Dal;
using Dal.Context;
using Dal.Entity;
using Microsoft.EntityFrameworkCore;

namespace Business;

public class UserService : IUserService
{
    private readonly ChatDbContext _chatDbContext;

    public UserService(ChatDbContext chatDbContext)
    {
        _chatDbContext = chatDbContext;
    }

    public Task<int> AddUser(AddUserDto user)
    {
        var newUser = new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            Password = user.Password
        };

        _chatDbContext.Users.AddAsync(newUser);
        return _chatDbContext.SaveChangesAsync();
    }

    public async Task<GetUserDto> getUserById(int userId)
    {
        var selectedUser = await _chatDbContext.Users.Where(p => !p.IsDeleted && p.Id == userId)
        .Select(p => new GetUserDto
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            UserName = p.UserName,
            RegisterDate = p.RegisterDate
        }).FirstOrDefaultAsync();

       return selectedUser;


    }


   
}
