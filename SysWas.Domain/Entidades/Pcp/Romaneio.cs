using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Projetos;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Pcp
{
    public class Romaneio : Entidade
    {

        public int Id { get; set; }
        public FichaTecnica FichaProduto { get; set; }





        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }


    }
}
