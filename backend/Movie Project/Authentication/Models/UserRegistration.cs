using System.ComponentModel.DataAnnotations;

namespace Authentication.Models
{
    public class UserRegistration
    {
        [Key]
        public String Email { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }



    }
}
