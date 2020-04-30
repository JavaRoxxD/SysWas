using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Insumos
{
    public class TipoInsumo : Entidade
    {

        public int Id { get; set; }
        public string Tipo { get; set; }


        public TipoInsumo() { }

      



        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }



    }
}
