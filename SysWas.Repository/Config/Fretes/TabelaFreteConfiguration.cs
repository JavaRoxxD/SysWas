using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fretes;

namespace SysWas.Repository.Config.Fretes
{
    public class TabelaFreteConfiguration : IEntityTypeConfiguration<TabelaFrete>
    {
        public void Configure(EntityTypeBuilder<TabelaFrete> builder)
        {


            builder.HasKey(t => t.Id);


            //1 >>> 1
            builder.HasOne(t => t.Veiculo);
            //1 >>> 1
            builder.HasOne(t => t.Proprietario);

            

            builder
                .Property(t => t.DataCriacao)
                .IsRequired();

            builder
                .Property(t => t.Ativo)
                .IsRequired();


            //1 >>> *
            builder
                .HasMany(t => t.Itens)
                .WithOne(i => i.Tabela);



        }
    }
}
