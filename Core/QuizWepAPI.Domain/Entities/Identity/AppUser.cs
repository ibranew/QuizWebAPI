using Microsoft.AspNetCore.Identity;

namespace QuizWepAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
    }
}
