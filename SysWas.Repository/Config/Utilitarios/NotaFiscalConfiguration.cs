using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Repository.Config.Utilitarios
{
    public class NotaFiscalConfiguration : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {


            builder.HasKey(n => n.Id);

            builder
                .Property(n => n.Numero)
                .IsRequired();

            builder
                .Property(n => n.Valor)
                .HasColumnType("decimal(19,2)")
                .IsRequired();

            builder
                .Property(n => n.Documento);


        }
    }
}
