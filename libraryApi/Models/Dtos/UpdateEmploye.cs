using System.ComponentModel.DataAnnotations;

namespace libraryApi.Models.Dtos
{
    public class UpdateEmploye
    {
        [Required, StringLength(100)]
        public string Nom { get; set; }

        [Required, StringLength(100)]
        public string Prenom { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }

      
    }
}
