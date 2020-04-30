import { Madeira } from './madeira';
import { Empresa } from '../empresas/empresa';
import { Lote } from './lote';

export class Fardo {

    id: number;
    numero: number;
    quantidade: number;
    volume: number;

  madeiraId: number;
  madeira: Madeira;
  proprietarioId: number;
  proptrietario: Empresa;
    baixa: boolean;
  loteId: number;
  lote: Lote;

}
