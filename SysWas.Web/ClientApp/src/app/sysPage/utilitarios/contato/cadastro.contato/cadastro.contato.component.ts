import { Component, OnInit, ViewChild } from '@angular/core';

import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatInput } from '@angular/material';

import { stringify } from '@angular/compiler/src/util';
import { ContatoService } from '../../../../services/utilitarios/contato.service';
import { Contato } from '../../../../model/utilitarios/contato';


@Component({
  selector: 'contato',
  templateUrl: './contato.component.html',
  styleUrls: ['./contato.component.css']
})
export class ContatoComponent implements OnInit {


  constructor(private contatoService: ContatoService,
    private router: Router) { }

  public contato: Contato;
  public contatoReturn: Contato;


  public mensagem: string;
  private ativar_spinner: boolean;
  public arquivoSelecionado: File;

  // descricaoFc = new FormControl('', [Validators.required, Validators.minLength(10)]);
  nomeFc = new FormControl('', [Validators.required]);




  ngOnInit() {



    let contatoSession = sessionStorage.getItem('contatoSession');
    if (contatoSession) {

      this.contato = JSON.parse(contatoSession);

      // this.tipo = this.contato.tipo;
      // this.especie = this.contato.especie;
      // this.controle = this.contato.controle;

    } else {
      this.contato = new Contato();

    }


  }




  cadastrar() {

    console.log(this.contato);

    this.ativarEspera();
    this.contatoService.cadastrar(this.contato)
      .subscribe(

        contatoJson => {

          // console.log(contatoJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisa-contato']);


        },
        e => {

          // console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }


      );



  }

  deletar() {

    this.contatoService.deletar(this.contato)
      .subscribe(


      );

  }

  obterTodosContato() {

    this.contatoService.obterTodosContato()
      .subscribe(


      );

  }

  obterContato(id: number) {

    this.contatoService.obterContato(id)
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
