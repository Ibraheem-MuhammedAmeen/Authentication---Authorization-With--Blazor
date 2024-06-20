using DemoBlazorServerJWTAuthentication.Data;
using DemoBlazorServerJWTAuthentication.DTOs;
using DemoBlazorServerJWTAuthentication.Responses;
using Microsoft.Identity.Client;
using DemoBlazorServerJWTAuthentication.Models;
using Microsoft.EntityFrameworkCore;
using static DemoBlazorServerJWTAuthentication.Responses.CustomResponses;
using System.Reflection.Metadata.Ecma335;
using System.Data.SqlTypes;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Data;
using System.Text;


namespace DemoBlazorServerJWTAuthentication.Repos
{
    public class Account : IAcount
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration config;

        public Account(AppDbContext appDbContext, IConfiguration config)
        {
            this.appDbContext = appDbContext;
            this.config = config;
        }


        public async Task<CustomResponses.LoginResponse> LoginAsync(LoginDTO model)
        {
            var findUser = await GetUser(model.Email);
            if (findUser == null) return new LoginResponse(false, "User not found");
            if (!BCrypt.Net.BCrypt.Verify(model.Password, findUser.Password))
                return new LoginResponse(false, "Email/Password not valid");
            string jwtToken = GenerateToken(findUser);
            return new LoginResponse(true, "Login successfull", jwtToken);
        }

        public async Task<CustomResponses.RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var findUser = await GetUser(model.Email);
            if (findUser != null) return new CustomResponses.RegistrationResponse(false,"User already exist");
            appDbContext.Users.Add(
                new ApplicationUser()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                });
            await appDbContext.SaveChangesAsync();
            return new RegistrationResponse(true,"Success");
        }

        private async Task<ApplicationUser> GetUser(string email)
            => await appDbContext.Users.FirstOrDefaultAsync(e => e.Email == email);

        private string GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Email, user.Email!)
            };
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"]!,
                audience: config["Jwt:Audience"]!,
                claims: userClaims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
