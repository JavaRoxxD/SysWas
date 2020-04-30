using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Insumos;

namespace SysWas.Repository.Config.Insumos
{
    public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {

            builder.HasKey(i => i.Id);

            builder
                .Property(i => i.Nome)
                .IsRequired();

            builder.HasOne(i => i.Tipo);

            builder.HasOne(i => i.Controle);

            builder
                .Property(i => i.Descricao)
                .IsRequired();



        }
    }
}
