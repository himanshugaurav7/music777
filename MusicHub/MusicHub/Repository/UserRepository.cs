using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MusicHub.Data;
using MusicHub.Model;
using MusicHub.Model.DTO;
using MusicHub.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicHub.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MusicHubDBContext _context;
        private readonly string SecretKey;

        public UserRepository(MusicHubDBContext context, IConfiguration configuration)
        {

            _context = context;
            SecretKey = configuration.GetValue<string>("JWT:Secret");
        }
        public bool IsUniqueUser(string username)
        {
           var user = _context.LocalUsers.FirstOrDefault(x => x.UserName== username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public  async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var user = _context.LocalUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequest.User.ToLower()
            && u.Password==loginRequest.Password);
            if (user == null)
            {
                return new LoginResponse()
                {
                    Token = "",
                    User = null
                };
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponse loginResponse = new()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };
            return loginResponse;

        }

        public async Task<LocalUser> Register(RegistrationRequest registrationRequest)
        {
            LocalUser user = new()
            {
                UserName = registrationRequest.UserName,
                Password = registrationRequest.Password,
                Role = registrationRequest.Role
            };
            await _context.LocalUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
