using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Madeiras;

namespace SysWas.Repository.Config.Madeiras
{
    public class EspecieMadeiraConfiguration : IEntityTypeConfiguration<EspecieMadeira>
    {
        public void Configure(EntityTypeBuilder<EspecieMadeira> builder)
        {
            
            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Especie)
                .IsRequired();
            
            

        }
    }
}
