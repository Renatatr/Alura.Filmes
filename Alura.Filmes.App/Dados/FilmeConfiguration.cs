using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    internal class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("film");
            builder.Property(a => a.Id).HasColumnName("film_id");
            builder.Property(a => a.Titulo).HasColumnName("title").HasColumnType("varchar(255)").IsRequired();
            builder.Property(a => a.Descricao).HasColumnName("description").HasColumnType("text");
            builder.Property(a => a.AnoLancamento).HasColumnName("release_year").HasColumnType("varchar(4)");
            builder.Property(a => a.Duracao).HasColumnName("length");
            builder.Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
        }
    }
}
