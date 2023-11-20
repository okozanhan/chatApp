using System;

namespace Dal;

public class GetUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public DateTime RegisterDate { get; set; }
}
