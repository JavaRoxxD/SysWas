import { Component, OnInit, ViewChild } from '@angular/core';
import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { EmpresaService } from '../../../../services/empresas/empresa.service';
import { Empresa } from '../../../../model/empresas/empresa';
import { EnderecoService } from '../../../../services/cep/endereco.service';
import { Endereco } from '../../../../model/cep/endereco';
import { CidadeService } from '../../../../services/cep/cidade.service';
import { EstadoService } from '../../../../services/cep/estado.service';
import { Estado } from '../../../../model/cep/estado';
import { Cidade } from '../../../../model/cep/cidade';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';




@Component({
  selector: 'cadastro-empresa',
  templateUrl: './cadastro.empresa.component.html',
  styleUrls: ['./cadastro.empresa.component.css']
})
export class CadastroEmpresaComponent implements OnInit {


  public empresa: Empresa;
  public endereco: Endereco;
  public enderecos: Endereco[];
  public estados: Estado[];
  public estado: Estado;
  public cidades: Cidade[];
  public cidade: Cidade;
  public enderecoParse: Endereco;
  public pesquisaLogradouro: boolean;
  public mensagem: string;
  private ativar_spinner: boolean;



  constructor(
    private enderecoService: EnderecoService,
    private empresaService: EmpresaService,
    private cidadeService: CidadeService,
    private estadoService: EstadoService,
    private router: Router
  ) { }

  // descricaoFc = new FormControl('', [Validators.required, Validators.minLength(10)]);

  public mask = [/[0-9]/, /\d/,/\d/,/\d/,/\d/,'-',/\d/,/\d/,/\d/]
  public maskCnpj = [/[1-9]/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '/', /\d/, /\d/, /\d/, /\d/,'-', /\d/, /\d/]


  cepFc = new FormControl('', [Validators.required, Validators.maxLength(9), Validators.minLength(9)]);
  logradouroFc = new FormControl({ value: '', disabled: true }, [Validators.required]);
  complementoFc = new FormControl('', [Validators.required]);
  bairroFc = new FormControl('', [Validators.required]);
  localidadeFc = new FormControl({ value: '', disabled: true }, [Validators.required]);
  ufFc = new FormControl({ value: '', disabled: true }, [Validators.required]);
  
  cnpjFc = new FormControl('', [Validators.required]);
  nomeFantasiaFc = new FormControl('', [Validators.required]);
  enderecoCepFc = new FormControl('', [Validators.required, Validators.maxLength(8), Validators.minLength(8)]);
  numeroEnderecoFc = new FormControl(['', Validators.required]);
  observacaoFc = new FormControl('');


  ngOnInit() {

    

    let empresaSession = sessionStorage.getItem('empresaSession');

    
    if (empresaSession) {

      this.empresa = new Empresa();
      this.endereco = new Endereco();

      this.empresa = JSON.parse(empresaSession);

      this.cnpjFc.setValue(this.empresa.cnpj);
      this.nomeFantasiaFc.setValue(this.empresa.nomeFantasia);
      this.numeroEnderecoFc.setValue(this.empresa.numeroEndereco);
      this.observacaoFc.setValue(this.empresa.observacao);

      
      this.cepFc.setValue(this.empresa.endereco.cep);
      this.logradouroFc.setValue(this.empresa.endereco.logradouro);
      this.complementoFc.setValue(this.empresa.endereco.complemento);
      this.bairroFc.setValue(this.empresa.endereco.bairro);
      this.localidadeFc.setValue(this.empresa.endereco.localidade);
      this.ufFc.setValue(this.empresa.endereco.uf);
      
      this.endereco.cep = this.empresa.endereco.cep;

    } else {

      this.empresa = new Empresa();
      this.endereco = new Endereco();
      

    }

    
    


  }



  cadastrar() {


     this.cadastrarEmpresa();
   

  }


  cadastrarEmpresa() {

    this.empresa.cnpj = this.cnpjFc.value;
    this.empresa.nomeFantasia = this.nomeFantasiaFc.value;
    this.empresa.numeroEndereco = this.numeroEnderecoFc.value;
    this.empresa.observacao = this.observacaoFc.value;
    

    this.ativarEspera();
    this.empresaService.cadastrar(this.empresa)
      .subscribe(

        empresaJson => {
          this.desativarEspera();
          this.router.navigate(['/pesquisa-empresa']);

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

  //public obterTodosEstados() {

  //  this.estadoService.obterTodosEstado()
  //    .subscribe(

  //      estados => {
  //        this.estados = estados;
         

  //    },
  //    e => {

  //      console.log(e.error);
  //      this.mensagem = e.erro;

  //    });

  //}
  //public obterTodasCidades() {


  //  this.cidadeService.obterTodosCidade(this.estado.id).subscribe(

  //    cidades => {
        

  //      this.cidades = cidades;
        
        

  //    },
  //    e => {

  //      console.log(e.error);
  //      this.mensagem = e.erro;

  //    });

  //}

  //public obterEnderecoLogradouro() {


    

  //  console.log(this.logradouroFc.value + this.localidadeFc.value + this.ufFc.value);
  //  this.enderecoService.obterEnderecoLogradouro(this.logradouroFc.value, this.cidade.nome, this.estado.nome)
  //    .subscribe(

  //      enderecos => {


  //        this.enderecos = enderecos;
          


  //      },
  //      e => {

  //        console.log(e.error);
  //        this.mensagem = e.erro;

  //      });


  //}


  public cadastrarEndereco() {



    this.endereco.cep = this.cepFc.value;

    this.enderecoService.cadastrar(this.endereco).subscribe(

      enderecoJson => {

        this.endereco = enderecoJson;
        this.empresa.enderecoId = this.endereco.id;
        this.empresa.endereco = enderecoJson;
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

  public ativarEspera() {
    this.ativar_spinner = true;
  }

  public desativarEspera() {
    this.ativar_spinner = false;
  }

  //public desbloquearLogradouro() {

  //  this.erroCep = true;
  //  this.pesquisaLogradouro = true;

  //  this.logradouroFc.enable();
  //  this.localidadeFc.enable();
  //  this.ufFc.enable();


  //}

  //public bloquearLogradouro() {

  //  this.erroCep = false;
  //  this.pesquisaLogradouro = false


  //}

  //public getEstado(estado) {
  //  this.estado = estado;

  //}
  //public getCidade(cidade) {
  //  this.cidade = cidade;

  //}
  //public getEndereco(endereco) {
  //  this.endereco = endereco;

  //}

  //public displayEstado(estado): string {

  //  return estado.nome;

  //}

  //public displayCidade(cidade): string {

  //  return cidade.nome;

  //}

  //public displayLogradouro(endereco): string {

  //  this.endereco = endereco;

  //  return endereco.logradouro;

  //}



  // getErrorMessage() {
  //  return this.validate.hasError('required') ? 'You must enter a value' :
  //    this.validate.hasError('email') ? 'Not a valid email' :
  //      '';
  // }




}
