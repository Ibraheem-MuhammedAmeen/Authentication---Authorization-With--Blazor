using DemoBlazorServerJWTAuthentication.DTOs;
using static DemoBlazorServerJWTAuthentication.Responses.CustomResponses;
namespace DemoBlazorServerJWTAuthentication.Services
{
    public interface IAccountService
    {
         Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model); 
    }
}
