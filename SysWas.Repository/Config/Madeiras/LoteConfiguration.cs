using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Madeiras;

namespace SysWas.Repository.Config.Madeiras
{
    public class LoteConfiguration : IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {

            builder.HasKey(l => l.Id);

            builder
                .Property(l => l.Quantidade)
                .IsRequired();

            builder
                .Property(l => l.Descricao)
                .IsRequired();

            builder
                .Property(l => l.Baixa)
                .IsRequired();

            builder
                .HasMany(l => l.ListaFardos)
                .WithOne(f => f.Lote);

            builder.HasOne(f => f.Pedido);

        }
    }
}
