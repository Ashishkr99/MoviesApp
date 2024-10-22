using Authentication.Models;
using Authentication.Repository;

namespace Authentication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repo;
        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }
        public void AddUser(UserRegistration user)
        {
                repo.AddUser(user);
        }

        public UserRegistration GetUserByEmail(string email)
        {
            return repo.GetUserByEmail(email);
        }
    }
}
