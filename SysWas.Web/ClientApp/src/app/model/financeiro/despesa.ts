import { TipoDespesa } from './tipoDespesa';
import { FormaPagamento } from '../utilitarios/formaPagamento';
import { EstadoAprovacao } from '../utilitarios/estadoAprovacao';

export class Despesa {

  id: number;
    valor: number;

    dataEmissao: Date;
    dataVencimento: Date;

    pago: boolean;

  tipoId: number;
  tipo: TipoDespesa;
  pagamentoId: number;
  pagamento: FormaPagamento;
  aprovacaoId: number;
  aprovacao: EstadoAprovacao;


}
