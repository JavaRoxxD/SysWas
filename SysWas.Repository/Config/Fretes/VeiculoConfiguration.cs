using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fretes;

namespace SysWas.Repository.Config.Fretes
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(v => v.Id);

            builder
                .Property(v => v.Placa)
                .IsRequired();

            builder
                .Property(v => v.QuantEixos)
                .IsRequired();

            builder.HasOne(v => v.Proprietario);



        }
    }
}
