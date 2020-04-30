using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Repository.Config.Utilitarios
{
    public class SecEditConfiguration : IEntityTypeConfiguration<SecEdit>
    {
        public void Configure(EntityTypeBuilder<SecEdit> builder)
        {

            builder.HasKey(s => s.Id);

            builder
                .Property(s => s.DataRegistro)
                .IsRequired();

            builder
                .Property(s => s.DataAlteracao)
                .IsRequired();

            builder
                .Property(s => s.IdReg)
                .IsRequired();
            
            builder
                .Property(s => s.NomeReg)
                .IsRequired();

            builder.HasOne(s => s.User);


        }
    }
}
