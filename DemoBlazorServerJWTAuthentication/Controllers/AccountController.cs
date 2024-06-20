using DemoBlazorServerJWTAuthentication.DTOs;
using DemoBlazorServerJWTAuthentication.Repos;
using DemoBlazorServerJWTAuthentication.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static DemoBlazorServerJWTAuthentication.Responses.CustomResponses;

namespace DemoBlazorServerJWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAcount accountrepo;

        public AccountController(IAcount accountrepo)
        {
            this.accountrepo = accountrepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegisterDTO model)
        {
            var result = await accountrepo.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginDTO model)
        {
            var result = await accountrepo.LoginAsync(model);
            return Ok(result);
        }
    }
}
