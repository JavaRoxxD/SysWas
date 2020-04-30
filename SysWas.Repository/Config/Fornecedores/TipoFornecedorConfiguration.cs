using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fornecedores;

namespace SysWas.Repository.Config.Fornecedores
{
    public class TipoFornecedorConfiguration : IEntityTypeConfiguration<TipoFornecedor>
    {
        public void Configure(EntityTypeBuilder<TipoFornecedor> builder)
        {

            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.Tipo)
                .IsRequired();

            builder
                .Property(t => t.Insumo)
                .IsRequired();

            builder
                .Property(t => t.Madeira)
                .IsRequired();




        }
    }
}
