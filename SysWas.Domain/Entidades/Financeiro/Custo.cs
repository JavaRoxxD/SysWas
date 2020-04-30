using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;


namespace SysWas.Domain.Entidades.Financeiro
{
    public class Custo : Entidade
    {
        public int Id { get; set; }
        public double Valor { get; set; }

        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Pago { get; set; }


        public int TipoId { get; set; }
        public virtual TipoCusto Tipo { get; set; }
        public int PagamentoId { get; set; }
        public virtual FormaPagamento Pagamento { get; set; }

        public int AprovavaoId { get; set; }
        public virtual EstadoAprovacao Aprovacao { get; set; }


        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }


    }
}
