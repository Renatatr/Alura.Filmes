using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Filmes.App.Dados
{
    public class PessoaConfiguration<T> : IEntityTypeConfiguration<T> where T : Pessoa
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.PrimeiroNome).HasColumnName("first_name").HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.UltimoNome).HasColumnName("last_name").HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(50)");
            builder.Property(x => x.Ativo).HasColumnName("active");
            builder.Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();

        }
    }
}
