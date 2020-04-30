using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fornecedores;

namespace SysWas.Repository.Config.Fornecedores
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {

            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.TipoF);

            builder
                .Property(f => f.RazaoSocial)
                .IsRequired();

            builder
                .Property(f => f.NomeFantasia)
                .IsRequired();

            builder
                .Property(f => f.Cnpj)
                .IsRequired();

            builder
                .Property(f => f.InscricaoEstadual)
                .IsRequired();

            builder
                .Property(f => f.InscricaoMunicipal)
                .IsRequired();

            //builder
            //    .Property(f => f.Rg)
            //    .IsRequired();

            //builder
            //    .Property(f => f.Emissor)
            //    .IsRequired();

            //builder.HasOne(f => f.Uf);
            //builder.HasOne(f => f.SexoPessoa);

            //builder
            //    .Property(f => f.DataNascimento)
            //    .IsRequired();

            builder
                .Property(f => f.Telefone)
                .IsRequired();

            builder
                .Property(f => f.Celular)
                .IsRequired();

            builder
                .Property(f => f.Email)
                .IsRequired();

            builder
                .Property(f => f.Site)
                .IsRequired();

            builder
                .Property(f => f.EmailNotaFiscal)
                .IsRequired();

            builder
                .Property(f => f.Observacao)
                .IsRequired();

            builder.HasOne(f => f.ListaContatoFornecedor);
            builder.HasOne(f => f.EnderecoFornecedor);

            builder
                .Property(f => f.NumEndereco)
                .IsRequired();

            builder
                .Property(f => f.Transportadora)
                .IsRequired();

            


        }
    }
}
