using DemoBlazorServerJWTAuthentication.DTOs;
using DemoBlazorServerJWTAuthentication.Responses;
using DemoBlazorServerJWTAuthentication.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static DemoBlazorServerJWTAuthentication.Responses.CustomResponses;

public class AccountService : IAccountService
{
    private readonly HttpClient httpClient;

    public AccountService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<LoginResponse> LoginAsync(LoginDTO model)
    {
        var response = await httpClient.PostAsJsonAsync("api/account/login", model);
        return await response.Content.ReadFromJsonAsync<LoginResponse>();
    }

    public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
    {
        var response = await httpClient.PostAsJsonAsync("api/account/register", model);
        return await response.Content.ReadFromJsonAsync<RegistrationResponse>();
    }
}
