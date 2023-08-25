using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alura.Filmes.App.Dados
{
    public class IdiomaConfiguration : IEntityTypeConfiguration<Idioma>
    {
        public void Configure(EntityTypeBuilder<Idioma> builder)
        {
            builder.ToTable("language");
            builder.Property(x => x.Id).HasColumnName("language_id");
            builder.Property(x => x.Nome).HasColumnName("name").HasColumnType("charvar(20)").IsRequired();
        }
    }
}
