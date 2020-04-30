using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Financeiro;

namespace SysWas.Repository.Config.Financeiro
{
    public class DreConfiguration : IEntityTypeConfiguration<Dre>
    {
        public void Configure(EntityTypeBuilder<Dre> builder)
        {


            builder.HasKey(d => d.Id);

            builder
                .Property(d => d.DataInicio)
                .IsRequired();

            builder
                .Property(d => d.DataFim)
                .IsRequired(); 

            builder
                .Property(d => d.ValorCusto)
                .IsRequired();

            builder
                .Property(d => d.ValorDespesa)
                .IsRequired();

            builder
                .Property(d => d.ValorReceita)
                .IsRequired();

            builder
                .Property(d => d.SaldoAnterior)
                .IsRequired();

            builder
                .Property(d => d.SaldoAtual)
                .IsRequired();




        }
    }
}
