using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.CEP;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Empresas
{
    public class Empresa : Entidade
    {

        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public int NumeroEndereco { get; set; }
        public string Observacao { get; set; }







        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }

    }
}
