import { Component, OnInit, ViewChild } from '@angular/core';

import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatInput } from '@angular/material';

import { stringify } from '@angular/compiler/src/util';
import { BancoService } from '../../../../services/utilitarios/banco.service';
import { Banco } from '../../../../model/utilitarios/banco';


@Component({
  selector: 'banco',
  templateUrl: './banco.component.html',
  styleUrls: ['./banco.component.css']
})
export class BancoComponent implements OnInit {


  constructor(private bancoService: BancoService,
    private router: Router) { }

  public banco: Banco;
  public bancoReturn: Banco;


  public mensagem: string;
  private ativar_spinner: boolean;
  public arquivoSelecionado: File;

  // descricaoFc = new FormControl('', [Validators.required, Validators.minLength(10)]);
  nomeFc = new FormControl('', [Validators.required]);
  



  ngOnInit() {



    let bancoSession = sessionStorage.getItem('bancoSession');
    if (bancoSession) {

      this.banco = JSON.parse(bancoSession);

      // this.tipo = this.banco.tipo;
      // this.especie = this.banco.especie;
      // this.controle = this.banco.controle;

    } else {
      this.banco = new Banco();

    }


  }

  


  cadastrar() {

    console.log(this.banco);

    this.ativarEspera();
    this.bancoService.cadastrar(this.banco)
      .subscribe(

        bancoJson => {

          // console.log(bancoJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisa-banco']);


        },
        e => {

          // console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }


      );



  }

  deletar() {

    this.bancoService.deletar(this.banco)
      .subscribe(


      );

  }

  obterTodosBanco() {

    this.bancoService.obterTodosBanco()
      .subscribe(


      );

  }

  obterBanco(id: number) {

    this.bancoService.obterBanco(id)
      .subscribe(


      );

  }

  compareFn(compare1: any, compare2: any) {

    return compare1 && compare2 ? compare1.id === compare2.id : compare1 === compare2;

  }


  public ativarEspera() {
    this.ativar_spinner = true;
  }

  public desativarEspera() {
    this.ativar_spinner = false;
  }
  // getErrorMessage() {
  //  return this.validate.hasError('required') ? 'You must enter a value' :
  //    this.validate.hasError('email') ? 'Not a valid email' :
  //      '';
  // }




}
