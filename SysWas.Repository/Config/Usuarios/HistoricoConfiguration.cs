using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Usuarios;

namespace SysWas.Repository.Config.Usuarios
{
    public class HistoricoConfiguration : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {

            builder.HasKey(h => h.Id);

            builder
                .Property(h => h.DataHistorico)
                .IsRequired();

            builder
                .Property(h => h.AcaoRealizada)
                .IsRequired();

            builder
                .Property(h => h.Tabela)
                .IsRequired();

            builder
                .Property(h => h.IdAcao)
                .IsRequired();




        }
    }
}
