using MusinfoDB.Models;

namespace MusinfoWebAPI.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        public static UserResponse GetUserResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                RoleId = user.RoleId
            };
        }
    }
}
