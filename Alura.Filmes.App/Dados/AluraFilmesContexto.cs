using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;

namespace Alura.Filmes.App.Dados
{
    internal class AluraFilmesContexto : DbContext
    {
        public DbSet<Ator> Atores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AluraFilmesTST;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ator>().ToTable("actor");
            modelBuilder.Entity<Ator>().Property(a => a.Id).HasColumnName("actor_id");
            modelBuilder.Entity<Ator>().Property(a => a.PrimeiroNome).HasColumnName("first_name").HasColumnType("varchar(45").IsRequired();
            modelBuilder.Entity<Ator>().Property(a => a.UltimoNome).HasColumnName("last_name").HasColumnType("varchar(45").IsRequired();

            //modelBuilder.Entity<Personagem>().ToTable("lotr_characters");
            //modelBuilder.Entity<Personagem>().Property(p => p.Id).HasColumnName("character_id");
            //modelBuilder.Entity<Personagem>().Property(p => p.Nome).HasColumnName("character_name").HasColumnType("varchar(60)").IsRequired();

        }


    }
}
