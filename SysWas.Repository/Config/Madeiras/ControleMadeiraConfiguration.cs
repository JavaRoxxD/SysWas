using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Madeiras;

namespace SysWas.Repository.Config.Madeiras
{
    public class ControleMadeiraConfiguration : IEntityTypeConfiguration<ControleMadeira>
    {
        public void Configure(EntityTypeBuilder<ControleMadeira> builder)
        {
            builder.HasKey(c => c.Id);


            builder
                .Property(c => c.Nome)
                .IsRequired();

            builder
                .Property(c => c.QuantAlerta);


            builder
                .Property(c => c.VolumeAlerta);
                

        }
    }
}
