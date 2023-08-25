using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    internal class ClienteConfiguration : PessoaConfiguration<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

            builder.ToTable("customer");
            builder.Property(a => a.Id).HasColumnName("customer_id");
            builder.Property<DateTime>("create_date").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();

        }
    }
}
