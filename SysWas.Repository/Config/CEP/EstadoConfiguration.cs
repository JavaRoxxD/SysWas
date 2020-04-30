using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.CEP;

namespace SysWas.Repository.Config.CEP
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {

            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Nome)
                .IsRequired();

           



        }
    }
}
