using Dal;

namespace Business;

public interface IUserService
{
    Task<int> AddUser(AddUserDto addUserDto);
    Task<GetUserDto> getUserById(int id);
    Task<List<GetUserDto>> GetUserList();


}
