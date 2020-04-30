using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.CEP;

namespace SysWas.Repository.Config.CEP
{
    public class EnderecoConfiguration: IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .HasIndex(e => e.Cep)
                .IsUnique();

            builder
                .Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(80);

            builder
                .Property(e => e.Complemento)
                .HasMaxLength(40);

            builder
                .Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(60);

            builder
                .Property(e => e.Localidade)
                .IsRequired()
                .HasMaxLength(60);

            builder
                .Property(e => e.Uf)
                .IsRequired()
                .HasMaxLength(5);



        }
    }
}
