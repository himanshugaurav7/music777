using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicHub.Model;
using MusicHub.Repository.IRepository;

namespace MusicHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;        
        public UserController(IUserRepository userRepo)
        {
           _userRepo = userRepo;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var loginResponse = await _userRepo.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token) )
                {
                return BadRequest(new { message = "Username or Password is Empty" });
            }
            return Ok(loginResponse);   
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegistrationRequest rrequest)
        {
            bool ifUserNameUnique = _userRepo.IsUniqueUser(rrequest.UserName);
            if (!ifUserNameUnique) 
            {
                return BadRequest(new {message ="User Already Registered"});
            }
            var user = _userRepo.Register(rrequest);
            if (user == null) 
            {
                return BadRequest(new { message = "Error While Registering" });
            }
            return Ok(new { message = "User registered successfully" });
          
        }
            
    }
}
