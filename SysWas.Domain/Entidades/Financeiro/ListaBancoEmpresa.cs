using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Empresas;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Financeiro
{
    public class ListaBancoEmpresa : Entidade
    {

        public int Id { get; set; }

        public int Agencia { get; set; }
        public int DigitoAgencia { get; set; }
        public int Conta { get; set; }
        public double Saldo { get; set; }

        public int BancoId { get; set; }
        public virtual Banco Banco { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Proprietario { get; set; }


        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }


    }
}
