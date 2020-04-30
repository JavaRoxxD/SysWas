using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fretes;

namespace SysWas.Repository.Config.Fretes
{
    public class FreteConfiguration : IEntityTypeConfiguration<Frete>
    {
        public void Configure(EntityTypeBuilder<Frete> builder)
        {

            builder.HasKey(f => f.Id);

            builder
                .Property(f => f.DataEntrega)
                .IsRequired();

            
            builder.HasOne(f => f.Origem);
            builder.HasOne(f => f.Destino);
            builder.HasOne(f => f.Veiculo);
            builder
                .Property(f => f.Km)
                .IsRequired();
            builder
                .Property(f => f.Volume)
                .IsRequired();

            builder
                .Property(f => f.Distancia)
                .IsRequired();

            builder
                .Property(f => f.ValorFrete)
                .IsRequired();

            builder.HasOne(f => f.Aprovacao);




        }
    }
}
