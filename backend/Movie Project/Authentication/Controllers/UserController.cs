using Authentication.Models;
using Authentication.Repository;
using Authentication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService svc;
        public UserController(IUserService svc)
        {
            this.svc = svc;
        }

        [HttpPost]
        public IActionResult create([FromBody] UserRegistration userobj)
        {

            try
            {
                svc.AddUser(userobj);
                return Ok(new
                {
                    Status = 201,
                    message = "Registration Successful"
                });
            }
            catch (UserAlreadyExistsException ex)
            {
                return Conflict(new
                {
                    Status = 409,
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                // General exception handling
                return StatusCode(500, new
                {
                    Status = 500,
                    message = "An error occurred while processing your request.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("GetUserById")]
        public IActionResult GetByEmail(string email)
        {
            var user = svc.GetUserByEmail(email);

            // Check if the user is found, then return only the name
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Return only the name property
            var result = new { Name = user.UserName }; // Assuming 'Name' is the correct property

            return Ok(result);
        }
    }
}
