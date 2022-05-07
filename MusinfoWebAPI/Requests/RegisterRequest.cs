using MusinfoDB.Models;
using System.ComponentModel.DataAnnotations;

namespace MusinfoWebAPI.Requests
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Username is empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Wrong password")]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }

        public static User GetUserEntity(RegisterRequest request)
        {
            return new User
            {
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
                RoleId = 2
            };
        }

    }
}
