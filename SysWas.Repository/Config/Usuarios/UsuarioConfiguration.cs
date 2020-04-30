using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Usuarios;

namespace SysWas.Repository.Config.Usuarios
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {


            builder.HasKey(u => u.Id);

            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(40);

            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(40);

            builder
                .Property(u => u.SobreNome)
                .IsRequired()
                .HasMaxLength(40);

            builder.HasOne(u => u.Sexo);


        }
    }
}
