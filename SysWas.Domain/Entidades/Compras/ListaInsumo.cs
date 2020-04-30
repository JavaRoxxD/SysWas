using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Insumos;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Compras
{
    public class ListaInsumo : Entidade
    {

        public int Id { get; set; }

        public int InsumoId { get; set; }
        public virtual Insumo Insumo { get; set; }
        public int Quantidade { get; set; }

        public double Volume { get; set; }




        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }

    }
}
