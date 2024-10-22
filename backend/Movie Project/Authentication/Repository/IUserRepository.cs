using Authentication.Models;

namespace Authentication.Repository
{
    public interface IUserRepository
    {
        void AddUser(UserRegistration user);
        UserRegistration GetUserByEmail(String email);
    }
}
