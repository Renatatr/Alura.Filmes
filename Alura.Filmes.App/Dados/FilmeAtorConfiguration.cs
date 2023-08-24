using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FilmeAtorConfiguration : IEntityTypeConfiguration<FilmeAtor>
    {
        public void Configure(EntityTypeBuilder<FilmeAtor> builder)
        {
            builder.ToTable("film_actor");
            builder.Property<int>("film_id").IsRequired();
            builder.Property<int>("actor_id").IsRequired();
            builder.Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
            builder.HasKey("film_id", "actor_id");

            builder.HasOne(x => x.Filme).WithMany(x => x.Atores).HasForeignKey("film_id");
            builder.HasOne(x => x.Ator).WithMany(x => x.Filmografia).HasForeignKey("actor_id");

        }
    }
}
