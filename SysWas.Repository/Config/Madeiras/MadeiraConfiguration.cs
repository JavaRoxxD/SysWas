using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Madeiras;

namespace SysWas.Repository.Config.Madeiras
{
    public class MadeiraConfiguration : IEntityTypeConfiguration<Madeira>
    {
        public void Configure(EntityTypeBuilder<Madeira> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Descricao)
                .IsRequired();

            builder
                .Property(m => m.Espessura)
                .IsRequired();

            builder
                .Property(m => m.Largura)
                .IsRequired();

            builder
                .Property(m => m.Comprimento)
                .IsRequired();

            builder
                .Property(m => m.PreBenef)
                .IsRequired();

            builder.HasOne(m => m.Tipo);
            builder.HasOne(m => m.Especie);
            builder.HasOne(m => m.Controle);


       


        }
    }
}
