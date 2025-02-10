using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Services;
using System;
using System.Threading.Tasks;
using static MyProject.Models.AuthDtos;
namespace MyProject.Controllers
{
    [Route("api/forgot-password")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotOasswordDto model)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                return BadRequest(new { message = "Email not found." });
            }

            user.ResetToken = Guid.NewGuid().ToString();
            user.ResetTokenExpires = DateTime.UtcNow.AddMinutes(15);

            await _context.SaveChangesAsync();

            var resetUrl = $"https://yourfrontend.com/reset-password?token={user.ResetToken}"; // لسه ناقص

            await EmailService.SendEmailAsync(user.Email, "Reset password", $"Use the following link: {resetUrl}");

            return Ok(new { message = "A password reset link has been sent." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.ResetToken == model.Token && u.ResetTokenExpires > DateTime.UtcNow);

            if (user == null)
            {
                return BadRequest(new { message = "The reset code is invalid or expired." });
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
            user.ResetToken = null;
            user.ResetTokenExpires = null;

            await _context.SaveChangesAsync();

            return Ok(new { message = "The password has been changed successfully." });
        }
    }
}
