using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Insumos;

namespace SysWas.Repository.Config.Insumos
{
    public class ControleInsumoConfiguration : IEntityTypeConfiguration<ControleInsumo>
    {
        public void Configure(EntityTypeBuilder<ControleInsumo> builder)
        {

            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Nome)
                .IsRequired();

            builder
                .Property(c => c.QuantAlerta)
                .IsRequired();

            builder
                .Property(c => c.VolumeAlerta)
                .IsRequired();

            
            builder
                .Property(c => c.Ativo)
                .IsRequired();




        }
    }
}
