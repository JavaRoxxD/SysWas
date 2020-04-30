import { Banco } from '../utilitarios/banco';
import { Empresa } from '../empresas/empresa';

export class ListaBancoEmpresa {
    id: number;
    agencia: number;
    digitoAgencia: number;
    conta: number;
    saldo: number;

  bancoId: number;
  banco: Banco;
  empresaId: number;
  empresa: Empresa;
}
