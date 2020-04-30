using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Madeiras;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Compras
{
    public class ListaMadeira : Entidade
    {

        public int Id { get; set; }
        public int Quantidade { get; set; }
        public double Volume { get; set; }


        public int MadeiraId { get; set; }
        public virtual Madeira Madeira { get; set; }



        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }

    }
}
