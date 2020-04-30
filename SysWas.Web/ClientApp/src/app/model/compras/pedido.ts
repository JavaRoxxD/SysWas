import { Fornecedor } from '../Fornecedores/fornecedor';
import { Empresa } from '../empresas/empresa';
import { EstadoPedido } from './estadoPedido';
import { NotaFiscal } from '../utilitarios/notaFiscal';

export class Pedido {
    id: number;
    dataPedido: Date;
    dataPrevisao: Date;
    dataEntrega: Date;
    rnc: boolean;
  fornecedorId: number;
  fornecedor: Fornecedor;
  empresaId: number;
  empresa: Empresa;
  estadoPedidoId: number;
  estadoPedido: EstadoPedido;
  notaFiscalId: number;
  notaFiscal: NotaFiscal;
    observacao: string;

}

