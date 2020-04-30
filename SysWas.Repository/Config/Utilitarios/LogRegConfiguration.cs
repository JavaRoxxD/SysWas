using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Repository.Config.Utilitarios
{
    public class LogRegConfiguration : IEntityTypeConfiguration<LogReg>
    {
        public void Configure(EntityTypeBuilder<LogReg> builder)
        {
            
            builder.HasKey(l => l.Id);

            builder
                .Property(l => l.Log)
                .IsRequired();

        }
    }
}
