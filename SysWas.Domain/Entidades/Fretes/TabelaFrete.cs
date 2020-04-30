using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Fretes
{
    public class TabelaFrete : Entidade
    {

        public int Id { get; set; }

        public int VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public int ProprietarioId { get; set; }
        public virtual Transportadora Proprietario { get; set; }

        public virtual ICollection<ItemTabelaFrete> Itens { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Ativo { get; set; }



        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }

    }
}
