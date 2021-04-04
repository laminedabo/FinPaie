using Microsoft.AspNetCore.Identity;

namespace FinPaie.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
    }
}
