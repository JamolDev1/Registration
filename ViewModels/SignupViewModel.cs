using System.ComponentModel.DataAnnotations;

namespace webapp.ViewModels;

public class SignupViewModel : IValidatableObject
{
    public string ReturnUrl { get; set; }
    
    [Required(ErrorMessage = "Enetr Name and Surname")]
    [Display(Name = "Name Surname")]
    public string Fullname { get; set; }

    [Required(ErrorMessage = "Date of Bith")]
    [Display(Name = "Date of Bith")]
    public DateTimeOffset Birthdate { get; set; }
    
    [Required(ErrorMessage = "Enter your phone number")]
    [RegularExpression(@"^[\+]?(998[-\s\.]?)([0-9]{2}[-\s\.]?)([0-9]{3}[-\s\.]?)([0-9]{2}[-\s\.]?)([0-9]{2}[-\s\.]?)$",
    ErrorMessage = "Format of the phone number is incorrects")]
    [Display(Name = "Phone number")]
    public string Phone { get; set; }
    
    [Required(ErrorMessage = "Enter your email")]
    [EmailAddress(ErrorMessage = "Format of the email is incorrect")]
    [Display(Name = "Your email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Enter your username")]
    [Display(Name = "Username")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Enter your password")]
    [MinLength(6, ErrorMessage = "Password must contain at least 6 charectors")]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm your password")]
    [Compare(nameof(Password), ErrorMessage = "Pasword is incorrect , check your password")]
    [Display(Name = "Confirm your password")]
    public string ConfirmPassword { get; set; }
    
    [Display(Name = "Remember")]
    public bool RememberMe { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var now = DateTimeOffset.Now;
        var limit = new DateTime(now.Year - 13, now.Month, now.Day);
        Console.WriteLine($"{limit} {Birthdate}");

        if(Birthdate > limit)
        {
            yield return new ValidationResult($"You must be older than 13 ", new [] { nameof(Birthdate)});
        }
    }
}