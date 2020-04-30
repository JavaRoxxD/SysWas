using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fretes;

namespace SysWas.Repository.Config.Fretes
{
    public class MotoristaConfiguration : IEntityTypeConfiguration<Motorista>
    {
        public void Configure(EntityTypeBuilder<Motorista> builder)
        {

            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Nome)
                .IsRequired();

            builder
                .Property(m => m.NumCnh)
                .IsRequired();

            builder
                .Property(m => m.Cpf)
                .IsRequired();

            builder
                .Property(m => m.Rg)
                .IsRequired();

            builder
                .Property(m => m.DataNascimento)
                .IsRequired();

            builder.HasOne(m => m.Sexo);
            





        }
    }
}
