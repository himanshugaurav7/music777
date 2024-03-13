using MusicHub.Model;

namespace MusicHub.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<LocalUser> Register(RegistrationRequest registrationRequest);
    }
}
