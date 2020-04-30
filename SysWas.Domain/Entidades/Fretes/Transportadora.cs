using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fornecedores;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Fretes
{
    public class Transportadora : Entidade
    {

        public int Id { get; set; }


        public int FornecedorId { get; set; }
        public virtual Fornecedor FornecedorTransporte { get; set; }





        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }



    }
}
