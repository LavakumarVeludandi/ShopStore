using ShopStore.Constants;

namespace ShopStore.Dto;

public class UserDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public Role Role { get; set; }
}

