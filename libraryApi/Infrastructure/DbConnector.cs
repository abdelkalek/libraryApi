using libraryApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace libraryApi.Infrastructure
{
    public class DbConnector  :IdentityDbContext<ApplicationUser>
    {
        public DbConnector(DbContextOptions<DbConnector> options) : base(options)
        {

        }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<TypeLivre> TypeLivres { get; set; }

    }
}