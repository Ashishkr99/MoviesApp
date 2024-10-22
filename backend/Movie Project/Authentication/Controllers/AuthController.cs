using Authentication.Models;
using Authentication.Repository;
using Authentication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginRepository repo;
        private readonly ITokenGenerator tg;
        public AuthController(ILoginRepository repo, ITokenGenerator tg)
        {
            this.repo = repo;
            this.tg = tg;
        }
        
        [HttpPost]
        [Route("Login")]
        public IActionResult Logins([FromBody] login Login)
        {

            try
            {
                var res = repo.Auth(Login);

                if (res != null)
                {
                    var token = tg.GenerateToken(res.Email);
                    return Ok(new
                    {
                        Status = 200,
                        message = "Login Successful",
                        Token = token
                    });
                }
                else
                {
                    // Return 401 Unauthorized for invalid credentials
                    return Unauthorized(new
                    {
                        Status = 401,
                        message = "Invalid email or password. Please try again."
                    });
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that may occur
                return StatusCode(500, new
                {
                    Status = 500,
                    message = "An error occurred while processing your request.",
                    error = ex.Message
                });
            }

        }
    }
}
