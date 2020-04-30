using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Fretes
{
    public class Veiculo : Entidade
    {

        public int Id { get; set; }
        public string Placa { get; set; }
        public int QuantEixos { get; set; }

        public int ProprietarioId { get; set; }
        public virtual Transportadora Proprietario { get; set; }




        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }


    }
}
