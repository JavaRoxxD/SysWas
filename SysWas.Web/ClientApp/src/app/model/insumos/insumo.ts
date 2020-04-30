import { TipoInsumo } from "./tipoInsumo";
import { ControleInsumo } from "./controleInsumo";

export class Insumo {

    id: number;
    nome: string;
  tipoId: number;
  tipo: TipoInsumo;

  controleId: number;
  controle: ControleInsumo;
    descricao: string;


}
