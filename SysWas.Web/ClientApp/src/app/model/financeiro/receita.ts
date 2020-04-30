import { TipoReceita } from './tipoReceita';
import { FormaPagamento } from '../utilitarios/formaPagamento';
import { EstadoAprovacao } from '../utilitarios/estadoAprovacao';

export class Receita {

    id: number;
    valor: number;

    dataEmissao: Date;
    dataVencimento: Date;

    recebeu: boolean;

  tipoId: number;
  tipo: TipoReceita;
  pagamentoId: number;
  pagamento: FormaPagamento;
  aprovacaoId: number;
  aprovacao: EstadoAprovacao;

}
