using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Repository.Config.Utilitarios
{
    public class EstadoAprovacaoConfiguration : IEntityTypeConfiguration<EstadoAprovacao>
    {
        public void Configure(EntityTypeBuilder<EstadoAprovacao> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Nome)
                .IsRequired();

            builder
                .Property(e => e.Descricao)
                .IsRequired();



        }
    }
}
