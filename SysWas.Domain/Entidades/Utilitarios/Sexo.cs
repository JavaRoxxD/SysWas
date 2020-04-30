using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Usuarios;

namespace SysWas.Domain.Entidades.Utilitarios
{
    public class Sexo : Entidade
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        
   
        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }

    }
}
