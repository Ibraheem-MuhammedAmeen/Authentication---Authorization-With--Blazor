using System.ComponentModel.DataAnnotations;

namespace DemoBlazorServerJWTAuthentication.DTOs
{
    public class RegisterDTO: LoginDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        
        [Required, Compare(nameof(Password)), DataType(DataType.Password)]

        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
