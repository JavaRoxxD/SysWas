import { ListaContato } from './listaContato';
import { Endereco } from '../cep/endereco';
import { TipoFornecedor } from './tipoFornecedor';
import { ListaBancaria } from './listaBancaria';

export class Fornecedor {

id: number;
tipoFornecedorId: number;
tipoF: TipoFornecedor;
razaoSocial: string;
nomeFantasia: string;
cnpj: string;
inscricaoEstadual: string;
inscricaoMunicipal: string;
telefone: string;
celular: string;
email: string;
site: string;
emailNotaFiscal: string;
observacao: string;
listaContatoId: number;
listaContato: ListaContato;
enderecoCep: string;
enderecoFornecedorId: number;
enderecoFornecedor: Endereco;
numEndereco: number;
transportadora: boolean;




}
