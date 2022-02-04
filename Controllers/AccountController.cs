using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapp.Entity;
using webapp.ViewModels;

namespace webapp.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userM;
    private readonly SignInManager<User> _signInM;
    private readonly ILogger<AccountController> _logger;

    public AccountController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ILogger<AccountController> logger)
    {
        _userM = userManager;
        _signInM = signInManager;
        _logger = logger;
    }

    [HttpGet("signup")]
    public IActionResult Signup(string returnUrl)
    {
        return View(new SignupViewModel() { ReturnUrl = returnUrl ?? string.Empty });
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(SignupViewModel model)
    {
        var user = new User()
        {
            Fullname = model.Fullname,
            Email = model.Email,
            UserName = model.Username,
            Birthdate = model.Birthdate,
            PhoneNumber = model.Phone,
        };

        var result = await _userM.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return LocalRedirect($"/Login?returnUrl={model.ReturnUrl}");
        }

        return BadRequest(JsonSerializer.Serialize(result.Errors));
    }

    [HttpGet("Login")]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel() { ReturnUrl = returnUrl ?? string.Empty });
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var user = await _userM.FindByEmailAsync(model.Email);
        if (user != null)
        {
            await _signInM.PasswordSignInAsync(user, model.Password, false, false); // isPersistant

            return LocalRedirect($"{model.ReturnUrl ?? "/"}");
        }

        return BadRequest("Wrong credentials");
    }
}