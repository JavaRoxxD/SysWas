using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Empresas;
using SysWas.Domain.Entidades.Fornecedores;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Fretes
{
    public class Frete : Entidade
    {

        public int Id { get; set; }

        public DateTime DataEntrega { get; set; }
        

        public int OrigemId { get; set; }
        public virtual Fornecedor Origem { get; set; }

        public int DestinoId { get; set; }
        public virtual Empresa Destino { get; set; }

        public int VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; }

        public bool Km { get; set; }
        public bool Volume { get; set; }

        public double Distancia { get; set; }
        public double ValorFrete { get; set; }


        public int AprovacaoId { get; set; }
        public virtual EstadoAprovacao Aprovacao { get; set; }





        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }



    }
}
