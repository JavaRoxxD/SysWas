export class Frete {

  id: number;
  dataEntrega: Date;

  origemId: number;
  destinoId: number;
  veiculoId: number;

  km: boolean;
  volume: boolean;

  distancia: number;

  valorFrete: number;
  aprovacaoId: number;

}


/*
        public int VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; }

        public bool Km { get; set; }
        public bool Volume { get; set; }

        public double Distancia { get; set; }
        public double ValorFrete { get; set; }


        public int AprovacaoId { get; set; }
        public virtual EstadoAprovacao Aprovacao { get; set; }*/
