using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fornecedores;

namespace SysWas.Repository.Config.Fornecedores
{
    public class ListaBancariaConfiguration : IEntityTypeConfiguration<ListaBancaria>
    {
        public void Configure(EntityTypeBuilder<ListaBancaria> builder)
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
                .Property(l => l.DigitoConta)
                .IsRequired();

            builder.HasOne(l => l.Banco);

            builder.HasOne(l => l.Fornecedor);


        }
    }
}
