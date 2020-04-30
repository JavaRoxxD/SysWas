using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Fretes
{
    public class ItemTabelaFrete : Entidade
    {
        public int Id { get; set; }

        public int TabelaId { get; set; }
        public virtual TabelaFrete Tabela { get; set; }

        public double Volume { get; set; }
        public double ValorVolume { get; set; }
        public double DistanciaMin { get; set; }
        public double DistanciaMax { get; set; }
        public double ValorDistancia { get; set; } //Por eixo

        //public double DescontoVolume { get; set; }
        //public double DescontoDistancia { get; set; }


        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
