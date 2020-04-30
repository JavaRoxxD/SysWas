using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Financeiro;

namespace SysWas.Repository.Config.Financeiro
{
    public class DespesaConfiguration : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {

            builder.HasKey(d => d.Id);

            builder
                .Property(d => d.DataEmissao)
                .IsRequired();
            builder
                .Property(d => d.Valor)
                .IsRequired();
            builder
                .Property(d => d.DataVencimento)
                .IsRequired();
            builder
                .Property(d => d.Pago)
                .IsRequired();

            builder.HasOne(d => d.Tipo);
            builder.HasOne(d => d.Pagamento);
            builder.HasOne(d => d.Aprovacao);

        }
    }
}
