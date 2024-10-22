using Authentication.Models;

namespace Authentication.Repository
{
    public interface ILoginRepository
    {
       UserRegistration Auth(login Login);
    }
}
