
using api_filmes_senai.Domains;
using Microsoft.EntityFrameworkCore;

namespace API_Filmes_SENAI.Context
{
    public class Filme_Context : DbContext
    {
        public Filme_Context()
        {

        }

        public Filme_Context(DbContextOptions<Filme_Context> options) : base(options)
        {

        }

        /// <summary>
        /// Define que as classes se transformarão em tabelas no BD!
        /// </summary>
        public DbSet<Genero> Genero { get; set; }

        public DbSet<Filme> Filme { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server= DESKTOP-EUMC23F\\SQLEXPRESS; Database = Api_filmes ; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true; ");
            }
        }
    }
}
