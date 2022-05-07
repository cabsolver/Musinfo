using MusinfoDB.Models;

namespace MusinfoWebAPI.Requests
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        public static User GetUserEntity(UserRequest request)
        {
            return new User
            {
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
                RoleId = request.RoleId
            };
        }
    }
}
