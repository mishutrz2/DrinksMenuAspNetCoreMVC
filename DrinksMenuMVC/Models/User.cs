using Microsoft.AspNetCore.Identity;

namespace DrinksMenuMVC.Models
{

    public enum UserRole
    {
        Normal,
        Contributor,
        Moderator,
        Admin
    }

    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Country { get; set; }
        public UserRole Role { get; set; }
        
    }
}
