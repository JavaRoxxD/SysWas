using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Compras;

namespace SysWas.Repository.Config.Compras
{
    public class ListaMadeiraConfiguration : IEntityTypeConfiguration<ListaMadeira>
    {
        public void Configure(EntityTypeBuilder<ListaMadeira> builder)
        {


            builder.HasKey(l => l.Id);

            builder
                .Property(l => l.Quantidade)
                .IsRequired();

            builder
                .Property(l => l.Volume)
                .IsRequired();

            builder.HasOne(l => l.Madeira);






        }
    }
}
