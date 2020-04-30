using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Compras;

namespace SysWas.Repository.Config.Compras
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {


            builder.HasKey(p => p.Id);




            builder
                .Property(p => p.DataPedido);

            builder
                .Property(p => p.DataPrevisao);

            builder
                .Property(p => p.DataEntrega);

            builder
                .Property(p => p.Observacao);

            builder
                .Property(p => p.Rnc);


            builder.HasOne(p => p.Fornecedor);

            builder.HasOne(p => p.Empresa);

            builder.HasOne(p => p.Notafiscal);





        }
    }
}
