using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Madeiras;

namespace SysWas.Repository.Config.Madeiras
{
    public class FardoConfiguration : IEntityTypeConfiguration<Fardo>
    {
        public void Configure(EntityTypeBuilder<Fardo> builder)
        {

            builder.HasKey(f => f.Id);

            builder
                .Property(f => f.Numero)
                .IsRequired();

            builder
                .Property(f => f.Quantidade)
                .IsRequired();

            builder
                .Property(f => f.Volume)
                .IsRequired();

            builder.HasOne(f => f.Madeira);

            builder.HasOne(f => f.Proprietario);

            builder
                .Property(f => f.Baixa)
                .IsRequired();

            builder.HasOne(f => f.Lote);


        }
    }
}
