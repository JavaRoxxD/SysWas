import { Component, OnInit, ViewChild } from '@angular/core';
import { Validators, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { FornecedorService } from '../../../../services/fornecedores/fornecedor.service';
import { Fornecedor } from '../../../../model/fornecedores/fornecedor';
import { EnderecoService } from '../../../../services/cep/endereco.service';
import { Endereco } from '../../../../model/cep/endereco';
import { ListaContato } from '../../../../model/Fornecedores/listaContato';
import { Contato } from '../../../../model/utilitarios/contato';
import { ListaBancaria } from '../../../../model/Fornecedores/listaBancaria';
import { Banco } from '../../../../model/utilitarios/banco';
import { TipoFornecedor } from '../../../../model/Fornecedores/tipoFornecedor';
import { TipoFornecedorService } from '../../../../services/fornecedores/tipoFornecedor.service';
import { ListaContatoService } from '../../../../services/fornecedores/listaContato.service';
import { ContatoService } from '../../../../services/utilitarios/contato.service';
import { ListaBancariaService } from '../../../../services/fornecedores/listaBancaria.service';
import { BancoService } from '../../../../services/utilitarios/banco.service';
import { MatDialog, MatSort, MatTableDataSource } from '@angular/material';
import { ContatoComponent } from '../../../dialog/contato/contato.component';



@Component({
  selector: 'cadastro-fornecedor',
  templateUrl: './cadastro.fornecedor.component.html',
  styleUrls: ['./cadastro.fornecedor.component.css']
})
export class CadastroFornecedorComponent implements OnInit {


  public fornecedor: Fornecedor;
  public tipoFornecedores: TipoFornecedor[];
  public selectedTipoFornecedor: TipoFornecedor;
  public endereco: Endereco;
  public enderecos: Endereco[];
  public listaContato: ListaContato;
  public contatos: Contato[];
  public listaBancaria: ListaBancaria;
  public bancos: Banco[];
  public selectedBanco: Banco;

  public mensagem: string;
  private ativar_spinner: boolean;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  displayedColumns: string[] = ['nome', 'cargo', 'email', 'telefone', 'editar', 'deletar'];
  dataSourceContato = new MatTableDataSource<Contato>();


  constructor(
    public dialog: MatDialog,
    private enderecoService: EnderecoService,
    private fornecedorService: FornecedorService,
    private tipoFornecedorService: TipoFornecedorService,
    private listaContatoService: ListaContatoService,
    private contatoService: ContatoService,
    private listaBancoService: ListaBancariaService,
    private bancoService: BancoService,
    private router: Router
  ) { }

  // descricaoFc = new FormControl('', [Validators.required, Validators.minLength(10)]);

  public mask = [/[0-9]/, /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/]
  public maskCnpj = [/[1-9]/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '/', /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/]
  public maskCel = ['(', /[0-9]/, /\d/, ')', /\d/, /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/]
  public maskTel = ['(', /[0-9]/, /\d/, ')', /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/]

  

  //Endereço
  cepFc = new FormControl('', [Validators.required, Validators.maxLength(9), Validators.minLength(9)]);
  logradouroFc = new FormControl({ value: '', disabled: true }, [Validators.required]);
  complementoFc = new FormControl('', [Validators.required]);
  bairroFc = new FormControl('', [Validators.required]);
  localidadeFc = new FormControl({ value: '', disabled: true }, [Validators.required]);
  ufFc = new FormControl({ value: '', disabled: true }, [Validators.required]);

  //Fornecedor
  razaoSocialFc = new FormControl('', [Validators.required]);
  tipoFornecedorFc = new FormControl('', [Validators.required]);
  nomeFantasiaFc = new FormControl('', [Validators.required]);
  cnpjFc = new FormControl('', [Validators.required]);
  inscricaoEstadualFc = new FormControl('', [Validators.required]);
  inscricaoMunicipalFc = new FormControl('', [Validators.required]);
  telefoneFc = new FormControl('', [Validators.required]);
  celularFc = new FormControl('');
  emailFc = new FormControl('', [Validators.required]);
  siteFc = new FormControl('');
  emailNotaFiscalFc = new FormControl('', [Validators.required]);
  observacaoFc = new FormControl('');

  numeroEnderecoFc = new FormControl(['', Validators.required]);

  


  ngOnInit() {

    this.dataSourceContato.sort = this.sort;
    sessionStorage.removeItem('contatoSession');

    this.obterTodosTipoFornecedor();
    this.obterTodosBanco();


    let fornecedorSession = sessionStorage.getItem('fornecedorSession');


    if (fornecedorSession) {

      this.fornecedor = new Fornecedor();
      this.endereco = new Endereco();
      this.contatos = new Array<Contato>();

      this.fornecedor = JSON.parse(fornecedorSession);

      this.cnpjFc.setValue(this.fornecedor.cnpj);
      this.nomeFantasiaFc.setValue(this.fornecedor.nomeFantasia);
      this.numeroEnderecoFc.setValue(this.fornecedor.numEndereco);
      this.observacaoFc.setValue(this.fornecedor.observacao);


      this.cepFc.setValue(this.fornecedor.enderecoFornecedor.cep);
      this.logradouroFc.setValue(this.fornecedor.enderecoFornecedor.logradouro);
      this.complementoFc.setValue(this.fornecedor.enderecoFornecedor.complemento);
      this.bairroFc.setValue(this.fornecedor.enderecoFornecedor.bairro);
      this.localidadeFc.setValue(this.fornecedor.enderecoFornecedor.localidade);
      this.ufFc.setValue(this.fornecedor.enderecoFornecedor.uf);

      this.endereco.cep = this.fornecedor.enderecoFornecedor.cep;

    } else {

      this.fornecedor = new Fornecedor();
      this.endereco = new Endereco();
      this.contatos = new Array<Contato>();

    }





  }



  cadastrar() {


    this.cadastrarFornecedor();


  }


  cadastrarFornecedor() {

    this.listaContatoService.cadastrar(new ListaContato).subscribe(
      lista => {

        this.fornecedor.listaContatoId = lista.id;

      },
      e => {

      }
    );

    this.fornecedor.cnpj = this.cnpjFc.value;
    this.fornecedor.nomeFantasia = this.nomeFantasiaFc.value;
    this.fornecedor.numEndereco = this.numeroEnderecoFc.value;
    this.fornecedor.observacao = this.observacaoFc.value;


    this.ativarEspera();
    this.fornecedorService.cadastrar(this.fornecedor)
      .subscribe(

        fornecedorJson => {
          this.desativarEspera();
          this.router.navigate(['/pesquisa-fornecedor']);

        },
        e => {
          this.mensagem = e.error;
          this.desativarEspera();
        }


      );

  }


  obterEndereco() {



    if (this.cepFc.value != "00000-000") {
      this.enderecoService.obterEndereco(this.cepFc.value)
        .subscribe(

          endereco => {



            this.endereco = endereco;

            this.cepFc.setValue(this.endereco.cep);
            this.logradouroFc.setValue(this.endereco.logradouro);
            this.complementoFc.setValue(this.endereco.complemento);
            this.bairroFc.setValue(this.endereco.bairro);
            this.localidadeFc.setValue(this.endereco.localidade);
            this.ufFc.setValue(this.endereco.uf);


            if (!this.endereco.logradouro && !this.endereco.bairro && !this.endereco.uf) {
              let retorno = confirm('Este CEP não foi encontrado! \nCaso não encontre o endereco, use: \n 00000-000');

              //this.desbloquearLogradouro();
            }
            if (this.endereco.logradouro && this.endereco.bairro && this.endereco.uf) {
              this.cadastrarEndereco();
            }

          },
          e => {

            console.log(e.error);
            this.mensagem = e.erro;

          });

    }
    else {
      this.cadastrarEndereco();
    }


  }

  public cadastrarEndereco() {



    this.endereco.cep = this.cepFc.value;

    this.enderecoService.cadastrar(this.endereco).subscribe(

      enderecoJson => {

        this.endereco = enderecoJson;
        this.fornecedor.enderecoFornecedorId = this.endereco.id;
        this.fornecedor.enderecoFornecedor = enderecoJson;
        this.cepFc.setValue(this.endereco.cep);
        this.logradouroFc.setValue(this.endereco.logradouro);
        this.complementoFc.setValue(this.endereco.complemento);
        this.bairroFc.setValue(this.endereco.bairro);
        this.localidadeFc.setValue(this.endereco.localidade);
        this.ufFc.setValue(this.endereco.uf);
      },
      e => {

        console.log(e.error);
        this.mensagem = e.error;
      });

  }

  public obterTodosTipoFornecedor() {

    this.tipoFornecedorService.obterTodosTipoFornecedor().subscribe(

      tipoFornecedores => {

        this.tipoFornecedores = tipoFornecedores;
        
      },
      e => {

        console.log(e.error);

      });


  }

  public obterTodosBanco() {

    this.bancoService.obterTodosBanco().subscribe(

      bancos => {

        this.bancos = bancos;

      },
      e => {

        console.log(e.error);

      });


  }


  public openDialogContato() {

    const dialogRef = this.dialog.open(ContatoComponent, { disableClose: true });
    dialogRef.afterClosed().subscribe(
      result => {

        console.log(result);

        if (result != false) {

          this.contatos.push(result);
          this.dataSourceContato.data = this.contatos;
        }
        else {
          
          sessionStorage.removeItem('contatoSession');
        }


      }
    );

  }


  public editarContato(contato: Contato) {

  }

  public deletarContato(contato: Contato) {

    let retorno = confirm('Deseja realmente deletar esse item?');

    if (retorno == true) {

      if (!contato.id) {

        var index = this.contatos.findIndex(element => element.email === contato.email && element.telefone === contato.telefone);
        console.log(index);
        this.contatos = this.contatos.slice(index, 0);
        this.dataSourceContato.data = this.contatos;

        this.contatos.forEach(function (value) {

          console.log(value);

        });

      }
      else {



      }
    }
    else {

    }

  }




  public ativarEspera() {
    this.ativar_spinner = true;
  }

  public desativarEspera() {
    this.ativar_spinner = false;
  }

  compareFn(compare1: any, compare2: any) {

    return compare1 && compare2 ? compare1.id === compare2.id : compare1 === compare2;

  }

}
