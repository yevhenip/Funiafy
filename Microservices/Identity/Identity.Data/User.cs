using Microsoft.AspNetCore.Identity;

namespace Identity.Data
{
    public class User : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime RegistrationDateTime { get; set; }
    }
}