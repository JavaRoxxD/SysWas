using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Empresas;

namespace SysWas.Repository.Config.Empresas
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {


            builder.HasKey(e => e.Id);


            builder
                .Property(e => e.NomeFantasia)
                .IsRequired()
                .HasMaxLength(60);

            builder.HasOne(e => e.Endereco);

            builder
                .Property(e => e.NumeroEndereco)
                .IsRequired();

            builder
                .Property(e => e.Observacao)
                .IsRequired()
                .HasMaxLength(80);





        }
    }
}
