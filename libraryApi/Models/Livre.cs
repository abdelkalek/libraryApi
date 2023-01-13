using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libraryApi.Models
{
    public class Livre
    {

        [Key, Column("id")]
        public Guid Id { get; set; }
        public string Titre { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public Guid TypeLivreID { get; set; }
        public virtual TypeLivre Type { get; set; }

        public Guid AuteurID { get; set; }
        public virtual Auteur Auteur { get; set; }
    }
}
