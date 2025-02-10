using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public static class AuthDtos
    {
        public class ForgotOasswordDto
        {
            [Required, EmailAddress]
            public string? Email { get; set; }
        }
        public class ResetPasswordDto
        {
            [Required]
            public string? Token { get; set; }
            [Required(ErrorMessage = "The Password field is required.")]
            [StringLength(100, MinimumLength = 8, ErrorMessage = "The password must be at least 8 characters long.")]
            [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "The password must contain at least 8 number, one letter, and one special character.")]
            public string? NewPassword { get; set; }
        }
    }
}
