﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SysWas.Domain.Entidades.Utilitarios
{
    public class Telefone : Entidade
    {

        public int Id { get; set; }
        public string Contato { get; set; }




        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }



    }
}
