using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Madeiras
{
    public class ControleMadeira : Entidade
    {

        public int Id { get; set; }

        public string Nome { get; set; }
        public int QuantAlerta { get; set; }
        public double VolumeAlerta { get; set; }





        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }




    }
}
