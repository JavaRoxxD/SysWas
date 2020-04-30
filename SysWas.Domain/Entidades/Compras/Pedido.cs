using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Empresas;
using SysWas.Domain.Entidades.Fornecedores;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Compras
{
    public class Pedido : Entidade
    {

        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataPrevisao { get; set; }
        public DateTime DataEntrega { get; set; }
        public bool Rnc { get; set; }


        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int EstadoPedidoId { get; set; }
        public virtual EstadoPedido EstadoPedido { get; set; }

        public int NotaFiscalId { get; set; }
        public virtual NotaFiscal Notafiscal { get; set; }

        public string Observacao { get; set; }




        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }


    }
}
