using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Financeiro;

namespace SysWas.Repository.Config.Financeiro
{
    public class CustoConfiguration : IEntityTypeConfiguration<Custo>
    {
        public void Configure(EntityTypeBuilder<Custo> builder)
        {


            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.DataEmissao)
                .IsRequired();

            builder
                .Property(c => c.DataVencimento)
                .IsRequired();

            builder
                .Property(c => c.Valor)
                .IsRequired();

            builder
                .Property(c => c.Pago)
                .IsRequired();

            builder.HasOne(c => c.Tipo);
            builder.HasOne(c => c.Pagamento);
            builder.HasOne(c => c.Aprovacao);






        }
    }
}
