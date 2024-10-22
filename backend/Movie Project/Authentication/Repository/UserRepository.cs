using Authentication.Models;

namespace Authentication.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        public UserRepository(DataContext context)
        {
            this.context = context;
        }
        public void AddUser(UserRegistration user)
        {
            // Check if user with the same email already exists
            var existingUser = context.registration.FirstOrDefault(t => t.Email == user.Email);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException($"User with email {user.Email} already exists.");
            }

            context.registration.Add(user);
            context.SaveChanges();
        }

        public UserRegistration GetUserByEmail(string email)
        {
            return context.registration.FirstOrDefault(t => t.Email == email);
        }
    }

    // Custom exception
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string message) : base(message)
        {
        }
    }
}

