using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Filmes.App.Dados
{
    internal class FilmeCategoriaConfiguration : IEntityTypeConfiguration<FilmeCategoria>
    {
        public void Configure(EntityTypeBuilder<FilmeCategoria> builder)
        {
            builder.ToTable("film_category");
            builder.Property<int>("film_id").IsRequired();
            builder.Property<byte>("category_id").IsRequired();
            builder.Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
            builder.HasKey("film_id", "category_id");

            builder.HasOne(x => x.Filme).WithMany(x => x.Categorias).HasForeignKey("film_id");
            builder.HasOne(x => x.Categoria).WithMany(x => x.Filmes).HasForeignKey("category_id");

        }
    }
}
