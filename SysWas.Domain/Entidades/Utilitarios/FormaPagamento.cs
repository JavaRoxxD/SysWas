using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Enumerados;

namespace SysWas.Domain.Entidades.Utilitarios
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }


        public FormaPagamento() { }



        public bool Boleto
        {
            get { return Id == (int)TipoFormaPagamentoEnum.Boleto; }
        }
        public bool CartaoCredito
        {
            get { return Id == (int)TipoFormaPagamentoEnum.CartaoCredito; }
        }
        public bool Deposito
        {
            get { return Id == (int)TipoFormaPagamentoEnum.Depoisto; }
        }
        public bool Cheque
        {
            get { return Id == (int)TipoFormaPagamentoEnum.Cheque; }
        }
        public bool NaoDefinido
        {
            get { return Id == (int)TipoFormaPagamentoEnum.NaoDefinido; }
        }


    }
}
