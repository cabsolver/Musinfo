using System.ComponentModel.DataAnnotations;

namespace MusinfoWebAPI.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "UserName is empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }
    }
}
