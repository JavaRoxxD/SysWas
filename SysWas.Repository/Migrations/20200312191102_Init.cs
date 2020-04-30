using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SysWas.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControleInsumo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    QuantAlerta = table.Column<int>(nullable: false),
                    VolumeAlerta = table.Column<double>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleInsumo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControleMadeira",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    QuantAlerta = table.Column<int>(nullable: false),
                    VolumeAlerta = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleMadeira", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    ValorDespesa = table.Column<double>(nullable: false),
                    ValorCusto = table.Column<double>(nullable: false),
                    ValorReceita = table.Column<double>(nullable: false),
                    SaldoAnterior = table.Column<double>(nullable: false),
                    SaldoAtual = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(maxLength: 80, nullable: false),
                    Complemento = table.Column<string>(maxLength: 40, nullable: true),
                    Bairro = table.Column<string>(maxLength: 60, nullable: false),
                    Localidade = table.Column<string>(maxLength: 60, nullable: false),
                    Uf = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EspecieMadeira",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Especie = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieMadeira", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoAprovacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAprovacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoPedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHistorico = table.Column<DateTime>(nullable: false),
                    AcaoRealizada = table.Column<string>(nullable: false),
                    Tabela = table.Column<string>(nullable: false),
                    IdAcao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListaContato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaContato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogReg",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Log = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogReg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    Documento = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Contato = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCusto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCusto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDespesa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDespesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoFornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: false),
                    Insumo = table.Column<bool>(nullable: false),
                    Madeira = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoInsumo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInsumo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMadeira",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMadeira", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoReceita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoReceita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cnpj = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(maxLength: 60, nullable: false),
                    EnderecoCep = table.Column<string>(nullable: true),
                    EnderecoId = table.Column<int>(nullable: true),
                    NumeroEndereco = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Cargo = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    ListaContatoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contato_ListaContato_ListaContatoId",
                        column: x => x.ListaContatoId,
                        principalTable: "ListaContato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motorista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    NumCnh = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    Rg = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    SexoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorista_Sexo_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Senha = table.Column<string>(maxLength: 40, nullable: false),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    SobreNome = table.Column<string>(maxLength: 40, nullable: false),
                    SexoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Sexo_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Custo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<double>(nullable: false),
                    DataEmissao = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    Pago = table.Column<bool>(nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    PagamentoId = table.Column<int>(nullable: false),
                    AprovavaoId = table.Column<int>(nullable: false),
                    AprovacaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Custo_EstadoAprovacao_AprovacaoId",
                        column: x => x.AprovacaoId,
                        principalTable: "EstadoAprovacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Custo_FormaPagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Custo_TipoCusto_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoCusto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<double>(nullable: false),
                    DataEmissao = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    Pago = table.Column<bool>(nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    PagamentoId = table.Column<int>(nullable: false),
                    AprovacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesa_EstadoAprovacao_AprovacaoId",
                        column: x => x.AprovacaoId,
                        principalTable: "EstadoAprovacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Despesa_FormaPagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Despesa_TipoDespesa_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoDespesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoFornecedorId = table.Column<int>(nullable: false),
                    RazaoSocial = table.Column<string>(nullable: false),
                    NomeFantasia = table.Column<string>(nullable: false),
                    Cnpj = table.Column<string>(nullable: false),
                    InscricaoEstadual = table.Column<string>(nullable: false),
                    InscricaoMunicipal = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Site = table.Column<string>(nullable: false),
                    EmailNotaFiscal = table.Column<string>(nullable: false),
                    Observacao = table.Column<string>(nullable: false),
                    ListaContatoId = table.Column<int>(nullable: false),
                    EnderecoCep = table.Column<string>(nullable: true),
                    EnderecoFornecedorId = table.Column<int>(nullable: true),
                    NumEndereco = table.Column<int>(nullable: false),
                    Transportadora = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Endereco_EnderecoFornecedorId",
                        column: x => x.EnderecoFornecedorId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fornecedor_ListaContato_ListaContatoId",
                        column: x => x.ListaContatoId,
                        principalTable: "ListaContato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fornecedor_TipoFornecedor_TipoFornecedorId",
                        column: x => x.TipoFornecedorId,
                        principalTable: "TipoFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insumo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    ControleId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insumo_ControleInsumo_ControleId",
                        column: x => x.ControleId,
                        principalTable: "ControleInsumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Insumo_TipoInsumo_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoInsumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Madeira",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    Espessura = table.Column<double>(nullable: false),
                    Largura = table.Column<double>(nullable: false),
                    Comprimento = table.Column<double>(nullable: false),
                    PreBenef = table.Column<bool>(nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    EspecieId = table.Column<int>(nullable: false),
                    ControleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Madeira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Madeira_ControleMadeira_ControleId",
                        column: x => x.ControleId,
                        principalTable: "ControleMadeira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Madeira_EspecieMadeira_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "EspecieMadeira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Madeira_TipoMadeira_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoMadeira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<double>(nullable: false),
                    DataEmissao = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    Recebeu = table.Column<bool>(nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    PagamentoId = table.Column<int>(nullable: false),
                    AprovacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receita_EstadoAprovacao_AprovacaoId",
                        column: x => x.AprovacaoId,
                        principalTable: "EstadoAprovacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receita_FormaPagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receita_TipoReceita_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoReceita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControleSaldo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SaldoAtual = table.Column<double>(nullable: false),
                    SaldoAnterior = table.Column<double>(nullable: false),
                    SaldoPrevisto = table.Column<double>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleSaldo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControleSaldo_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaBancoEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Agencia = table.Column<int>(nullable: false),
                    DigitoAgencia = table.Column<int>(nullable: false),
                    Conta = table.Column<int>(nullable: false),
                    Saldo = table.Column<double>(nullable: false),
                    BancoId = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaBancoEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaBancoEmpresa_Banco_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaBancoEmpresa_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecEdit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    IdReg = table.Column<int>(nullable: false),
                    NomeReg = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecEdit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecEdit_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaBancaria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Agencia = table.Column<int>(nullable: false),
                    DigitoAgencia = table.Column<int>(nullable: false),
                    Conta = table.Column<int>(nullable: false),
                    DigitoConta = table.Column<int>(nullable: false),
                    BandoId = table.Column<int>(nullable: false),
                    BancoId = table.Column<int>(nullable: true),
                    FornecedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaBancaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaBancaria_Banco_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListaBancaria_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataPedido = table.Column<DateTime>(nullable: false),
                    DataPrevisao = table.Column<DateTime>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    Rnc = table.Column<bool>(nullable: false),
                    FornecedorId = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    EstadoPedidoId = table.Column<int>(nullable: false),
                    NotaFiscalId = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_EstadoPedido_EstadoPedidoId",
                        column: x => x.EstadoPedidoId,
                        principalTable: "EstadoPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_NotaFiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "NotaFiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transportadora",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FornecedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportadora_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstoqueInsumo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueInsumo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstoqueInsumo_Insumo_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Insumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaInsumo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InsumoId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaInsumo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaInsumo_Insumo_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaMadeira",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    MadeiraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaMadeira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaMadeira_Madeira_MadeiraId",
                        column: x => x.MadeiraId,
                        principalTable: "Madeira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<long>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    PedidoId = table.Column<int>(nullable: false),
                    Baixa = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lote_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(nullable: false),
                    QuantEixos = table.Column<int>(nullable: false),
                    ProprietarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Transportadora_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Transportadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fardo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    MadeiraId = table.Column<int>(nullable: false),
                    ProprietarioId = table.Column<int>(nullable: false),
                    Baixa = table.Column<bool>(nullable: false),
                    LoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fardo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fardo_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fardo_Madeira_MadeiraId",
                        column: x => x.MadeiraId,
                        principalTable: "Madeira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fardo_Empresa_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    OrigemId = table.Column<int>(nullable: false),
                    DestinoId = table.Column<int>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: false),
                    Km = table.Column<bool>(nullable: false),
                    Volume = table.Column<bool>(nullable: false),
                    Distancia = table.Column<double>(nullable: false),
                    ValorFrete = table.Column<double>(nullable: false),
                    AprovacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frete_EstadoAprovacao_AprovacaoId",
                        column: x => x.AprovacaoId,
                        principalTable: "EstadoAprovacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frete_Empresa_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frete_Fornecedor_OrigemId",
                        column: x => x.OrigemId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frete_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TabelaFrete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VeiculoId = table.Column<int>(nullable: false),
                    ProprietarioId = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaFrete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaFrete_Transportadora_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Transportadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TabelaFrete_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTabelaFrete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TabelaId = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    ValorVolume = table.Column<double>(nullable: false),
                    DistanciaMin = table.Column<double>(nullable: false),
                    DistanciaMax = table.Column<double>(nullable: false),
                    ValorDistancia = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTabelaFrete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTabelaFrete_TabelaFrete_TabelaId",
                        column: x => x.TabelaId,
                        principalTable: "TabelaFrete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ControleMadeira",
                columns: new[] { "Id", "Nome", "QuantAlerta", "VolumeAlerta" },
                values: new object[] { 1, "SEM CONTROLE", 0, 0.0 });

            migrationBuilder.InsertData(
                table: "EspecieMadeira",
                columns: new[] { "Id", "Especie" },
                values: new object[,]
                {
                    { 1, "Eucalipto" },
                    { 2, "Pinos" }
                });

            migrationBuilder.InsertData(
                table: "EstadoAprovacao",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Aprovação em Espera", "Em Espera" },
                    { 2, "Pedido Negado", "Negado" },
                    { 3, "Pedido Aprovado", "Aprovado" }
                });

            migrationBuilder.InsertData(
                table: "FormaPagamento",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Forma de Pagamento Boleto", "Boleto" },
                    { 2, "Forma de Pagamento Cartão de Crédito", "Cartão de Crédito" },
                    { 3, "Forma de Pagamento Depósito", "Depósito" },
                    { 4, "Forma de Pagamento Cheque", "Cheque" }
                });

            migrationBuilder.InsertData(
                table: "Sexo",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Feminino" },
                    { 3, "Outros" }
                });

            migrationBuilder.InsertData(
                table: "TipoMadeira",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { 1, "Ripa" },
                    { 2, "Caibro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_ListaContatoId",
                table: "Contato",
                column: "ListaContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_ControleSaldo_EmpresaId",
                table: "ControleSaldo",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Custo_AprovacaoId",
                table: "Custo",
                column: "AprovacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Custo_PagamentoId",
                table: "Custo",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Custo_TipoId",
                table: "Custo",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_AprovacaoId",
                table: "Despesa",
                column: "AprovacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_PagamentoId",
                table: "Despesa",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_TipoId",
                table: "Despesa",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_EnderecoId",
                table: "Empresa",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Cep",
                table: "Endereco",
                column: "Cep",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueInsumo_ItemId",
                table: "EstoqueInsumo",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Fardo_LoteId",
                table: "Fardo",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Fardo_MadeiraId",
                table: "Fardo",
                column: "MadeiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Fardo_ProprietarioId",
                table: "Fardo",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_EnderecoFornecedorId",
                table: "Fornecedor",
                column: "EnderecoFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_ListaContatoId",
                table: "Fornecedor",
                column: "ListaContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_TipoFornecedorId",
                table: "Fornecedor",
                column: "TipoFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Frete_AprovacaoId",
                table: "Frete",
                column: "AprovacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Frete_DestinoId",
                table: "Frete",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Frete_OrigemId",
                table: "Frete",
                column: "OrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_Frete_VeiculoId",
                table: "Frete",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Insumo_ControleId",
                table: "Insumo",
                column: "ControleId");

            migrationBuilder.CreateIndex(
                name: "IX_Insumo_TipoId",
                table: "Insumo",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTabelaFrete_TabelaId",
                table: "ItemTabelaFrete",
                column: "TabelaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaBancaria_BancoId",
                table: "ListaBancaria",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaBancaria_FornecedorId",
                table: "ListaBancaria",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaBancoEmpresa_BancoId",
                table: "ListaBancoEmpresa",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaBancoEmpresa_EmpresaId",
                table: "ListaBancoEmpresa",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaInsumo_InsumoId",
                table: "ListaInsumo",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaMadeira_MadeiraId",
                table: "ListaMadeira",
                column: "MadeiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_PedidoId",
                table: "Lote",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Madeira_ControleId",
                table: "Madeira",
                column: "ControleId");

            migrationBuilder.CreateIndex(
                name: "IX_Madeira_EspecieId",
                table: "Madeira",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Madeira_TipoId",
                table: "Madeira",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorista_SexoId",
                table: "Motorista",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EmpresaId",
                table: "Pedido",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EstadoPedidoId",
                table: "Pedido",
                column: "EstadoPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_FornecedorId",
                table: "Pedido",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_NotaFiscalId",
                table: "Pedido",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_AprovacaoId",
                table: "Receita",
                column: "AprovacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_PagamentoId",
                table: "Receita",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_TipoId",
                table: "Receita",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_SecEdit_UserId",
                table: "SecEdit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaFrete_ProprietarioId",
                table: "TabelaFrete",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaFrete_VeiculoId",
                table: "TabelaFrete",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportadora_FornecedorId",
                table: "Transportadora",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_SexoId",
                table: "Usuario",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_ProprietarioId",
                table: "Veiculo",
                column: "ProprietarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "ControleSaldo");

            migrationBuilder.DropTable(
                name: "Custo");

            migrationBuilder.DropTable(
                name: "Despesa");

            migrationBuilder.DropTable(
                name: "Dre");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "EstoqueInsumo");

            migrationBuilder.DropTable(
                name: "Fardo");

            migrationBuilder.DropTable(
                name: "Frete");

            migrationBuilder.DropTable(
                name: "Historico");

            migrationBuilder.DropTable(
                name: "ItemTabelaFrete");

            migrationBuilder.DropTable(
                name: "ListaBancaria");

            migrationBuilder.DropTable(
                name: "ListaBancoEmpresa");

            migrationBuilder.DropTable(
                name: "ListaInsumo");

            migrationBuilder.DropTable(
                name: "ListaMadeira");

            migrationBuilder.DropTable(
                name: "LogReg");

            migrationBuilder.DropTable(
                name: "Motorista");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "SecEdit");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "TipoCusto");

            migrationBuilder.DropTable(
                name: "TipoDespesa");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "TabelaFrete");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "Insumo");

            migrationBuilder.DropTable(
                name: "Madeira");

            migrationBuilder.DropTable(
                name: "EstadoAprovacao");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "TipoReceita");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "ControleInsumo");

            migrationBuilder.DropTable(
                name: "TipoInsumo");

            migrationBuilder.DropTable(
                name: "ControleMadeira");

            migrationBuilder.DropTable(
                name: "EspecieMadeira");

            migrationBuilder.DropTable(
                name: "TipoMadeira");

            migrationBuilder.DropTable(
                name: "Sexo");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "EstadoPedido");

            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DropTable(
                name: "Transportadora");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "ListaContato");

            migrationBuilder.DropTable(
                name: "TipoFornecedor");
        }
    }
}
