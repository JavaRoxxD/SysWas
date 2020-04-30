using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Repository.Config.Utilitarios
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(c => c.Cargo)
                .IsRequired()
                .HasMaxLength(40);

            builder
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(c => c.Telefone)
                .IsRequired();

            builder.HasOne(c => c.Lista);

        }
    }
}
