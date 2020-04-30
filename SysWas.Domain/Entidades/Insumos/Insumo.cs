using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Insumos
{
    public class Insumo : Entidade
    {


        public int Id { get; set; }
        public string Nome { get; set; }

        public int TipoId { get; set; }
        public virtual TipoInsumo Tipo { get; set; }
        public int ControleId { get; set; }
        public virtual ControleInsumo Controle { get; set; }

        public string Descricao { get; set; }

        public Insumo() { }


        public Insumo(int id, string nome, TipoInsumo tipo, ControleInsumo controle) {

            this.Id = id;
            this.Nome = nome;
            this.Tipo = tipo;
            this.Controle = controle;
        
        
        }




        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }


    }
}
