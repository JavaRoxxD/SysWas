using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Financeiro
{
    public class Dre : Entidade
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public double ValorDespesa { get; set; }
        public double ValorCusto { get; set; }
        public double ValorReceita { get; set; }
        public double SaldoAnterior { get; set; }
        public double SaldoAtual { get; set; }


        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }




    }
}
