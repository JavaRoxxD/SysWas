using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Financeiro;

namespace SysWas.Repository.Config.Financeiro
{
    public class ReceitaConfiguration : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {


            builder.HasKey(r => r.Id);

            builder
                .Property(r => r.DataEmissao)
                .IsRequired();

            builder
                .Property(r => r.Valor)
                .IsRequired();

            builder
                .Property(r => r.DataEmissao)
                .IsRequired();

            builder
                .Property(r => r.DataVencimento)
                .IsRequired();

            builder
                .Property(r => r.Recebeu)
                .IsRequired();



            builder.HasOne(r => r.Aprovacao);
            builder.HasOne(r => r.Pagamento);
            builder.HasOne(r => r.Tipo);

        }
    }
}
