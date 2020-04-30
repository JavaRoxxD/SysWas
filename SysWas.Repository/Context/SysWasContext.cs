using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.CEP;
using SysWas.Domain.Entidades.Compras;
using SysWas.Domain.Entidades.Empresas;
using SysWas.Domain.Entidades.Financeiro;
using SysWas.Domain.Entidades.Fornecedores;
using SysWas.Domain.Entidades.Fretes;
using SysWas.Domain.Entidades.Insumos;
using SysWas.Domain.Entidades.Madeiras;
using SysWas.Domain.Entidades.Usuarios;
using SysWas.Domain.Entidades.Utilitarios;
using SysWas.Repository.Config.CEP;
using SysWas.Repository.Config.Compras;
using SysWas.Repository.Config.Empresas;
using SysWas.Repository.Config.Financeiro;
using SysWas.Repository.Config.Fornecedores;
using SysWas.Repository.Config.Fretes;
using SysWas.Repository.Config.Insumos;
using SysWas.Repository.Config.Madeiras;
using SysWas.Repository.Config.Usuarios;
using SysWas.Repository.Config.Utilitarios;

namespace SysWas.Repository.Context
{
    public class SysWasContext : DbContext 
    {

        #region DataSet

        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<EstadoPedido> EstadoPedido { get; set; }
        public DbSet<ListaInsumo> ListaInsumo { get; set; }
        public DbSet<ListaMadeira> ListaMadeira { get; set; }
        public DbSet<NotaFiscal> NotaFiscal { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<ControleSaldo> ControleSaldo { get; set; }
        public DbSet<Custo> Custo { get; set; }
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<Dre> Dre { get; set; }
        public DbSet<ListaBancoEmpresa> ListaBancoEmpresa { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<TipoCusto> TipoCusto { get; set; }
        public DbSet<TipoDespesa> TipoDespesa { get; set; }
        public DbSet<TipoReceita> TipoReceita { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<ListaBancaria> ListaBancaria { get; set; }
        public DbSet<ListaContato> ListaContato { get; set; }
        public DbSet<TipoFornecedor> TipoFornecedor { get; set; }
        public DbSet<Frete> Frete { get; set; }
        public DbSet<ItemTabelaFrete> ItemTabelaFrete { get; set; }
        public DbSet<Motorista> Motorista { get; set; }
        public DbSet<TabelaFrete> TabelaFrete { get; set; }
        public DbSet<Transportadora> Transportadora { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<ControleInsumo> ControleInsumo { get; set; }
        public DbSet<EstoqueInsumo> EstoqueInsumo { get; set; }
        public DbSet<Insumo> Insumo { get; set; }
        public DbSet<TipoInsumo> TipoInsumo { get; set; }
        public DbSet<ControleMadeira> ControleMadeira { get; set; }
        public DbSet<EspecieMadeira> EspecieMadeira { get; set; }
        public DbSet<Fardo> Fardo { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Madeira> Madeira { get; set; }
        public DbSet<TipoMadeira> TipoMadeira { get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Banco> Banco { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Email> Email { get; set; }

        public DbSet<EstadoAprovacao> EstadoAprovacao { get; set; }

        public DbSet<FormaPagamento> FormaPagamento { get; set; }

        public DbSet<LogReg> LogReg { get; set; }
        public DbSet<SecEdit> SecEdit { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        #endregion

        public SysWasContext(DbContextOptions options) : base(options){}

        #region ModelConfig

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Classes de mapeamento

            modelBuilder.ApplyConfiguration(new CidadeConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoConfiguration());

            modelBuilder.ApplyConfiguration(new EstadoPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ListaInsumoConfiguration());
            modelBuilder.ApplyConfiguration(new ListaMadeiraConfiguration());
            modelBuilder.ApplyConfiguration(new NotaFiscalConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());

            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());

            modelBuilder.ApplyConfiguration(new ControleSaldoConfiguration());
            modelBuilder.ApplyConfiguration(new CustoConfiguration());
            modelBuilder.ApplyConfiguration(new DespesaConfiguration());
            modelBuilder.ApplyConfiguration(new DreConfiguration());
            modelBuilder.ApplyConfiguration(new ListaBancoEmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new ReceitaConfiguration());
            modelBuilder.ApplyConfiguration(new TipoCustoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoDespesaConfiguration());
            modelBuilder.ApplyConfiguration(new ReceitaConfiguration());

            modelBuilder.ApplyConfiguration(new FornecedorConfiguration());
            modelBuilder.ApplyConfiguration(new ListaBancariaConfiguration());
            modelBuilder.ApplyConfiguration(new ListaContatoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoFornecedorConfiguration());

            modelBuilder.ApplyConfiguration(new FreteConfiguration());
            modelBuilder.ApplyConfiguration(new ItemTabelaFreteConfiguration());
            modelBuilder.ApplyConfiguration(new MotoristaConfiguration());
            modelBuilder.ApplyConfiguration(new TabelaFreteConfiguration());
            modelBuilder.ApplyConfiguration(new TransportadoraConfiguration());
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());

            modelBuilder.ApplyConfiguration(new ControleInsumoConfiguration());
            modelBuilder.ApplyConfiguration(new EstoqueInsumoConfiguration());
            modelBuilder.ApplyConfiguration(new InsumoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoInsumoConfiguration());

            modelBuilder.ApplyConfiguration(new ControleMadeiraConfiguration());
            modelBuilder.ApplyConfiguration(new EspecieMadeiraConfiguration());
            modelBuilder.ApplyConfiguration(new FardoConfiguration());
            modelBuilder.ApplyConfiguration(new LoteConfiguration());
            modelBuilder.ApplyConfiguration(new MadeiraConfiguration());
            modelBuilder.ApplyConfiguration(new TipoMadeiraConfiguration());

            modelBuilder.ApplyConfiguration(new HistoricoConfiguration());
            modelBuilder.ApplyConfiguration(new PermissaoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            modelBuilder.ApplyConfiguration(new BancoConfiguration());
            modelBuilder.ApplyConfiguration(new ContatoConfiguration());
            modelBuilder.ApplyConfiguration(new EmailConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoAprovacaoConfiguration());
            modelBuilder.ApplyConfiguration(new LogRegConfiguration());
            modelBuilder.ApplyConfiguration(new SecEditConfiguration());
            modelBuilder.ApplyConfiguration(new SexoConfiguration());
            modelBuilder.ApplyConfiguration(new TelefoneConfiguration());

            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento(){ Id = 1, Nome = "Boleto", Descricao = "Forma de Pagamento Boleto"},
                new FormaPagamento() { Id = 2, Nome = "Cartão de Crédito", Descricao = "Forma de Pagamento Cartão de Crédito" },
                new FormaPagamento() { Id = 3, Nome = "Depósito", Descricao = "Forma de Pagamento Depósito" },
                new FormaPagamento() { Id = 4, Nome = "Cheque", Descricao = "Forma de Pagamento Cheque" });

            modelBuilder.Entity<EstadoAprovacao>().HasData(
                new EstadoAprovacao() { Id = 1, Nome = "Em Espera", Descricao = "Aprovação em Espera" },
                new EstadoAprovacao() { Id = 2, Nome = "Negado", Descricao = "Pedido Negado" },
                new EstadoAprovacao() { Id = 3, Nome = "Aprovado", Descricao = "Pedido Aprovado" });

            modelBuilder.Entity<Sexo>().HasData(
                new Sexo() { Id = 1, Nome = "Masculino" },
                new Sexo() { Id = 2, Nome = "Feminino" },
                new Sexo() { Id = 3, Nome = "Outros" });

            modelBuilder.Entity<TipoMadeira>().HasData(
                new TipoMadeira() { Id = 1, Tipo = "Ripa"},
                new TipoMadeira() { Id = 2, Tipo = "Caibro" });

            modelBuilder.Entity<EspecieMadeira>().HasData(
                new EspecieMadeira() { Id = 1, Especie = "Eucalipto" },
                new EspecieMadeira() { Id = 2, Especie = "Pinos" }
                );

            modelBuilder.Entity<ControleMadeira>().HasData(
                new ControleMadeira() { Id = 1, Nome = "SEM CONTROLE", QuantAlerta = 0, VolumeAlerta = 0}
                );

            modelBuilder.Entity<Endereco>().HasData(new Endereco() { 
                Id = 1, Cep = "00000-000", Logradouro = "N/D", Bairro = "N/D", 
                Localidade = "N/D", Uf = "N/D", Complemento = "N/D"
            }
            );


            modelBuilder.Entity<TipoFornecedor>().HasData(
            new TipoFornecedor() { Id = 1, Madeira = true, Insumo = false, Tipo = "Madeira" },
            new TipoFornecedor() { Id = 2, Madeira = false, Insumo = true, Tipo = "Insumo" },
            new TipoFornecedor() { Id = 4, Madeira = false, Insumo = false, Tipo = "Serviços" },
            new TipoFornecedor() { Id = 5, Madeira = false, Insumo = false, Tipo = "Outros" }
            );

            base.OnModelCreating(modelBuilder);
        }

        #endregion





    }
}
