using Microsoft.AspNetCore.Identity;

namespace webapp.Entity;

public class User : IdentityUser
{
    public string Fullname { get; set; }

    public DateTimeOffset Birthdate { get; set; }
}