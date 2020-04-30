using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fretes;

namespace SysWas.Repository.Config.Fretes
{
    public class TransportadoraConfiguration : IEntityTypeConfiguration<Transportadora>
    {
        public void Configure(EntityTypeBuilder<Transportadora> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.FornecedorTransporte);

        }
    }
}
