using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fretes;

namespace SysWas.Repository.Config.Fretes
{
    public class ItemTabelaFreteConfiguration : IEntityTypeConfiguration<ItemTabelaFrete>
    {
        public void Configure(EntityTypeBuilder<ItemTabelaFrete> builder)
        {

            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Tabela);

            builder
                .Property(i => i.Volume)
                .IsRequired();

            builder
                .Property(i => i.ValorVolume)
                .IsRequired();

            builder
                .Property(i => i.DistanciaMin)
                .IsRequired();

            builder
                .Property(i => i.DistanciaMax)
                .IsRequired();

            builder
                .Property(i => i.ValorDistancia)
                .IsRequired();

       


        }
    }
}
