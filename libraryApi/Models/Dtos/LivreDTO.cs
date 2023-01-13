namespace libraryApi.Models.Dtos
{
    public class LivreDTO
    {
        public string Titre { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public Guid TypeId { get; set; }
        public Guid AuteurId { get; set; }


    }
}
