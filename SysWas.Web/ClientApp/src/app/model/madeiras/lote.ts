import { Pedido } from '../compras/pedido';

export class Lote {

    id: number;
    quantidade: number;
    descricao: string;

  baixa: boolean;

  pedidoId: number;
  pedido: Pedido;


}
