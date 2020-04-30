using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Insumos
{
    public class EstoqueInsumo : Entidade
    {

        public int Id { get; set; }
        public int Quantidade { get; set; }
        public double Volume { get; set; }


        public int ItemId { get; set; }
        public virtual Insumo Item { get; set; }




        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
