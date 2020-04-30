using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Madeiras;

namespace SysWas.Repository.Config.Madeiras
{
    public class TipoMadeiraConfiguration : IEntityTypeConfiguration<TipoMadeira>
    {
        public void Configure(EntityTypeBuilder<TipoMadeira> builder)
        {

            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.Tipo)
                .IsRequired();


        }
    }
}
