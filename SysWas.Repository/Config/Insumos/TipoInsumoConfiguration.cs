using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Insumos;

namespace SysWas.Repository.Config.Insumos
{
    public class TipoInsumoConfiguration : IEntityTypeConfiguration<TipoInsumo>
    {
        public void Configure(EntityTypeBuilder<TipoInsumo> builder)
        {

            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.Tipo)
                .IsRequired();

        }
    }
}
