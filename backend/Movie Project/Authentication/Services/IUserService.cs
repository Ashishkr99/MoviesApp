using Authentication.Models;

namespace Authentication.Services
{
    public interface IUserService
    {
        void AddUser(UserRegistration user);
        UserRegistration GetUserByEmail(String email);
    }
}
