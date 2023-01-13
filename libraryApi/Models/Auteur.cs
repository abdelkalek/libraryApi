
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace libraryApi.Models
{
    public class Auteur
    {

        [Key, Column("id")]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenom  { get; set; }
        [JsonIgnore]
        public virtual ICollection<Livre> Livre { get; set; }


    }
}
