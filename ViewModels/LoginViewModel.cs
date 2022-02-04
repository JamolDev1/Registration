using System.ComponentModel.DataAnnotations;

namespace webapp.ViewModels;

public class LoginViewModel
{
    public string ReturnUrl { get; set; }

    [Required(ErrorMessage = "Enter your email adress")]
    [EmailAddress(ErrorMessage = "Incorect format of email adress.")]
    [Display(Name = "Your email")]   
    public string Email { get; set; }

    [Required(ErrorMessage = "Enter the password")]
    [MinLength(6, ErrorMessage = "Password must contain at least 6 charectors")]
    [Display(Name = "Password")]
    public string Password { get; set; }
}