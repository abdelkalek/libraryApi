
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace libraryApi.Models
{
    public class TypeLivre
    {

        [Key, Column("id")]
        public Guid Id { get; set; }
        public String Designation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Livre> Livre { get; set; }

    }
}
