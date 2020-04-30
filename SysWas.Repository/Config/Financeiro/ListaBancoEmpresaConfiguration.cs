using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Financeiro;

namespace SysWas.Repository.Config.Financeiro
{
    public class ListaBancoEmpresaConfiguration : IEntityTypeConfiguration<ListaBancoEmpresa>
    {
        public void Configure(EntityTypeBuilder<ListaBancoEmpresa> builder)
        {


            builder.HasKey(l => l.Id);

            builder
                .Property(l => l.Agencia)
                .IsRequired();

            builder
                .Property(l => l.DigitoAgencia)
                .IsRequired();

            builder
                .Property(l => l.Conta)
                .IsRequired();

            builder
                .Property(l => l.Saldo)
                .IsRequired();

            builder.HasOne(l => l.Banco);
            builder.HasOne(l => l.Proprietario);







        }
    }
}
