using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Insumos;

namespace SysWas.Repository.Config.Insumos
{
    public class EstoqueInsumoConfiguration : IEntityTypeConfiguration<EstoqueInsumo>
    {
        public void Configure(EntityTypeBuilder<EstoqueInsumo> builder)
        {

            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Quantidade)
                .IsRequired();

            builder
                .Property(e => e.Volume)
                .IsRequired();

            builder.HasOne(e => e.Item);


        }
    }
}
