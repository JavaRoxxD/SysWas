using System;
using System.Collections.Generic;
using System.Text;


namespace SysWas.Domain.Entidades.Utilitarios
{
    public class NotaFiscal : Entidade
    {

        public int Id { get; set; }
        public int Numero { get; set; }
        public double Valor { get; set; }
        public string Documento { get; set; }
        public string Descricao { get; set; }


        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }

    }
}
