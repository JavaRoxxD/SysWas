using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysWas.Domain.Entidades.Compras;
using SysWas.Domain.Entidades.Empresas;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Madeiras
{
    public class Lote : Entidade

    {


        public int Id { get; set; }
        public long Quantidade { get; set; }
        
        public virtual ICollection<Fardo> ListaFardos { get; set; }

        public string Descricao { get; set; }

        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        public bool Baixa { get; set; }



        public Lote() { }


        public override void Validate()
        {

            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
            //if (!ListaFardos.Any())
            //    AddMessageValidation("O Lote deve ter pelo menos um fardo registrado");
        }



    }
}
