using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Madeiras
{
    public class Madeira : Entidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Espessura { get; set; }
        public double Largura { get; set; }
        public double Comprimento { get; set; }
        public bool PreBenef { get; set; }


        public int TipoId { get; set; }
        public virtual TipoMadeira Tipo { get; set; }
        public int EspecieId { get; set; }
        public virtual EspecieMadeira Especie { get; set; }
        public int ControleId { get; set; }
        public virtual ControleMadeira Controle { get; set; }


        public Madeira(){}

        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
            if (this.Descricao == "")
                AddMessageValidation("Não foi informado a Descrição da madeira!");

            if(this.Descricao.Length < 8)
                AddMessageValidation("A Descrição da madeira deve ter no min 8 caracteres!");

            if (this.Espessura == 0)
                AddMessageValidation("Não foi informado a Espessura!");

            if (this.Comprimento == 0)
                AddMessageValidation("Não foi informado o Comprimento!");

            if (this.Largura == 0)
                AddMessageValidation("Não foi informado a Largura!");

            if (this.TipoId == 0)
                AddMessageValidation("Não foi informado o Tipo");

            if (this.EspecieId == 0)
                AddMessageValidation("Não foi informado a Espécie");

            if (this.ControleId == 0)
                AddMessageValidation("Não foi informado o Controle!");

            if (this == null)
                AddMessageValidation("Houve um erro, tente novamente!");

        }

    }
}
