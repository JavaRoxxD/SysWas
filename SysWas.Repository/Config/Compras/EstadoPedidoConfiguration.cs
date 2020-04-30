using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Compras;

namespace SysWas.Repository.Config.Compras
{
    public class EstadoPedidoConfiguration : IEntityTypeConfiguration<EstadoPedido>
    {
        public void Configure(EntityTypeBuilder<EstadoPedido> builder)
        {

            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Estado)
                .IsRequired();




        }
    }
}
