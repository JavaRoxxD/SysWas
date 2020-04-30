using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Financeiro;

namespace SysWas.Repository.Config.Financeiro
{
    public class ControleSaldoConfiguration : IEntityTypeConfiguration<ControleSaldo>
    {
        public void Configure(EntityTypeBuilder<ControleSaldo> builder)
        {


            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.SaldoAtual)
                .IsRequired();

            builder
                .Property(c => c.SaldoAnterior)
                .IsRequired();

            builder
                .Property(c => c.SaldoPrevisto)
                .IsRequired();

            builder
                .Property(c => c.DataRegistro)
                .IsRequired();

            builder
                .Property(c => c.DataAtualizacao)
                .IsRequired();

            builder.HasOne(c => c.Proprietario);



        }
    }
}
