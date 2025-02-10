using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ContactController : ControllerBase
{
    private static List<ContactModel> contacts = new List<ContactModel>();

    [HttpGet]
    public IActionResult GetContacts()
    {
        return Ok(contacts);
    }

    [HttpPost]
    public IActionResult SubmitContact([FromBody] ContactModel contact)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();


            return BadRequest(new { message = "Validation failed", errors });

        }


        contacts.Add(contact);
        return Ok(new { message = "Contact submitted successfully!", contact });
    }
}

public class ContactModel
{
    [Required(ErrorMessage = "Full Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 characters")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Message is required")]
    [MinLength(10, ErrorMessage = "Message must be at least 10 characters long")]
    [MaxLength(500, ErrorMessage = "Message cannot exceed 500 characters")]
    public string Message { get; set; }


}