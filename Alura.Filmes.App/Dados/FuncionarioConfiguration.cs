using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FuncionarioConfiguration : PessoaConfiguration<Funcionario>
    {
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            base.Configure(builder);

            builder.ToTable("staff");
            builder.Property(a => a.Id).HasColumnName("staff_id");
            builder.Property(a => a.Login).HasColumnName("username").HasColumnType("varchar(16)").IsRequired();
            builder.Property(a => a.Senha).HasColumnName("password").HasColumnType("varchar(40)");
            builder.Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();

        }
    }
}
