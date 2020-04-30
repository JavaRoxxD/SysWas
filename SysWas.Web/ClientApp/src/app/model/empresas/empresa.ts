import { Endereco } from "../cep/endereco";

export class Empresa {


  id: number;
  cnpj: string;
  nomeFantasia: string;

  enderecoId: number;
  endereco: Endereco;
  numeroEndereco: number;
  observacao: string;

}
