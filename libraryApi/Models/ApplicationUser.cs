using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace libraryApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string Nom { get; set; }
        [Required, MaxLength(50)]
        public string Prenom { get; set; }
    }
}
