using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Empresas;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Madeiras
{
    public class Fardo : Entidade
    {

        public int Id { get; set; }
        public int Numero { get; set; }
        public int Quantidade { get; set; }
        public double Volume { get; set; }


        public int MadeiraId { get; set; }
        public virtual Madeira Madeira { get; set; }
        public int ProprietarioId { get; set; }
        public virtual Empresa Proprietario { get; set; }
        
        public bool Baixa { get; set; }


        public int LoteId { get; set; }
        public virtual Lote Lote { get; set; }



        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }

    }
}
