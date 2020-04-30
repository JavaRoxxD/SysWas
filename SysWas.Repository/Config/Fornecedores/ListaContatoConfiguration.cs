using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fornecedores;

namespace SysWas.Repository.Config.Fornecedores
{
    public class ListaContatoConfiguration : IEntityTypeConfiguration<ListaContato>
    {
        public void Configure(EntityTypeBuilder<ListaContato> builder)
        {

            builder.HasKey(l => l.Id);

            builder
                .HasMany(l => l.Contatos)
                .WithOne(c => c.Lista);
           


        }
    }
}
