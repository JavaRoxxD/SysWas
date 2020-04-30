import { TipoCusto } from './tipoCusto';
import { FormaPagamento } from '../utilitarios/formaPagamento';
import { EstadoAprovacao } from '../utilitarios/estadoAprovacao';

export class Custo {

    id: number;
    valor: number;

    dataEmissao: Date;
    dataVencimento: Date;

    pago: boolean;

  tipoId: number;
  tipo: TipoCusto;
  pagamentoId: number;
  pagamento: FormaPagamento;
  aprovacaoId: number;
  aprovacao: EstadoAprovacao;

}
