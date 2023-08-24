using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Filmes.App.Dados
{
    internal class AluraFilmesContexto : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AluraFilmes;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtorConfiguration());

            modelBuilder.ApplyConfiguration(new FilmeConfiguration());
 
            //modelBuilder.Entity<Personagem>().ToTable("lotr_characters");
            //modelBuilder.Entity<Personagem>().Property(p => p.Id).HasColumnName("character_id");
            //modelBuilder.Entity<Personagem>().Property(p => p.Nome).HasColumnName("character_name").HasColumnType("varchar(60)").IsRequired();

        }


    }
}
