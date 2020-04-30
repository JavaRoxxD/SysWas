using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Financeiro;

namespace SysWas.Repository.Config.Financeiro
{
    public class TipoReceitaConfiguration : IEntityTypeConfiguration<TipoReceita>
    {
        public void Configure(EntityTypeBuilder<TipoReceita> builder)
        {

            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.Tipo)
                .IsRequired();







        }
    }
}
