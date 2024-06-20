using DemoBlazorServerJWTAuthentication.DTOs;
using static DemoBlazorServerJWTAuthentication.Responses.CustomResponses;
namespace DemoBlazorServerJWTAuthentication.Repos
{
    public interface IAcount
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
    }
}
