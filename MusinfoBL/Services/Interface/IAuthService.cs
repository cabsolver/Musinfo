using MusinfoDB.Models;

namespace MusinfoBL.Services.Interface
{
    public interface IAuthService
    {
        public string Login(string username, string password);

        public string Register(User user);
    }
}
