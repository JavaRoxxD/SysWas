using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Usuarios;

namespace SysWas.Domain.Entidades.Utilitarios
{
    public class SecEdit : Entidade
    {

        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int IdReg { get; set; }
        public string NomeReg { get; set; }

        public int UserId { get; set; }
        public virtual Usuario User { get; set; }


        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }

    }
}
