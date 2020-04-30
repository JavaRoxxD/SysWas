using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Compras;

namespace SysWas.Repository.Config.Compras
{
    public class ListaInsumoConfiguration : IEntityTypeConfiguration<ListaInsumo>
    {
        public void Configure(EntityTypeBuilder<ListaInsumo> builder)
        {


            builder.HasKey(l => l.Id);

            builder
                .Property(l => l.Quantidade)
                .IsRequired();
            
            builder
                .Property(l => l.Volume)
                .IsRequired();

            builder.HasOne(l => l.Insumo);

            

        }
    }
}
