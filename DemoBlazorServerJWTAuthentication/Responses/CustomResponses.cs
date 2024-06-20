namespace DemoBlazorServerJWTAuthentication.Responses
{
    public class CustomResponses
    {
        public record RegistrationResponse(bool Flag= false, string Message = null!);
        public record LoginResponse(bool Flag = false, string Message = null!,string JWTToken = null!);
    }
}
