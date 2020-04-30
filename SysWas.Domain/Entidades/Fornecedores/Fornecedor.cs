using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.CEP;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Fornecedores
{
    public class Fornecedor : Entidade
    {

        public int Id { get; set; }
        public int TipoFornecedorId { get; set; }
        public virtual TipoFornecedor TipoF { get; set; }
        public string RazaoSocial { get; set; } //Pessoa Fisica Nome
        public string NomeFantasia { get; set; } //Pessoa Fisica Apelido
        public string Cnpj { get; set; } //Pessoa Fisica CPF
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }

        //Contato

        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string EmailNotaFiscal { get; set; }
        public string Observacao { get; set; }
        public int ListaContatoId { get; set; }
        public virtual ListaContato ListaContatoFornecedor { get; set; }
        public virtual Endereco EnderecoFornecedor { get; set; }
        public int NumEndereco { get; set; }
        public bool Transportadora { get; set; }


        





        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }

    }
}
