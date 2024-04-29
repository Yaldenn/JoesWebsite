using Microsoft.AspNetCore.Identity;

namespace RZAWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool? IsAdmin { get; set; } = false;
        public int RewardPoints { get; set; }

    }
}
