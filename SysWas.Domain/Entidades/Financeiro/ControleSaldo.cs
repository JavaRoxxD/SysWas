using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Empresas;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Financeiro
{
    public class ControleSaldo : Entidade
    {

        public int Id { get; set; }
        public double SaldoAtual { get; set; }
        public double SaldoAnterior { get; set; }
        public double SaldoPrevisto { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataAtualizacao { get; set; }


        public int EmpresaId { get; set; }
        public virtual Empresa Proprietario { get; set; }

        public ControleSaldo () {}



        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }

    }
}
