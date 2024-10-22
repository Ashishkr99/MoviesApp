using Authentication.Models;

namespace Authentication.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext dbcontext;
        public LoginRepository(DataContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public UserRegistration Auth(login Login)
        {
            return dbcontext.registration.FirstOrDefault(u => u.Email == Login.Email && u.Password == Login.Password);
        }
    }
}
