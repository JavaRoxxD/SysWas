import { EspecieMadeira } from './especieMadeira';
import { TipoMadeira } from './tipoMadeira';
import { ControleMadeira } from './controleMadeira';

export class Madeira {

  tipo: TipoMadeira;
  especie: EspecieMadeira;
  controle: ControleMadeira;

  id: number;
  descricao: string;
  espessura: number;
  largura: number;
  comprimento: number;
  preBenef: boolean;
  tipoId: number;
  especieId: number;
  controleId: number;


}
