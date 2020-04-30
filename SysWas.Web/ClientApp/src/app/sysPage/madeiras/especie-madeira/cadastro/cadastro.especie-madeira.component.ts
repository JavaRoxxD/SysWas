import { Component, OnInit, ViewChild } from '@angular/core';

import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatInput } from '@angular/material';
import { stringify } from '@angular/compiler/src/util';
import { EspecieMadeiraService } from '../../../../services/madeiras/especieMadeira.service';
import { EspecieMadeira } from '../../../../model/madeiras/especieMadeira';


@Component({
  selector: 'cadastro-especie-madeira',
  templateUrl: './cadastro.especie-madeira.component.html',
  styleUrls: ['./cadastro.especie-madeira.component.css']
})
export class CadastroEspecieMadeiraComponent implements OnInit {


  // public tipo: TipoEspecieMadeira;
  // public especie: EspecieEspecieMadeira;
  // public controle: ControleEspecieMadeira;



  constructor(
    private especieMadeiraService: EspecieMadeiraService,
    private router: Router
  ) { }

  public especieMadeira: EspecieMadeira;
  
  public mensagem: string;
  private ativar_spinner: boolean;
  public arquivoSelecionado: File;

  // descricaoFc = new FormControl('', [Validators.required, Validators.minLength(10)]);
  especieFc = new FormControl('', [Validators.required]);
 



  ngOnInit() {

   

    let especieMadeiraSession = sessionStorage.getItem('especieMadeiraSession');
    if (especieMadeiraSession) {

      this.especieMadeira = JSON.parse(especieMadeiraSession);
      
    } else {
      this.especieMadeira = new EspecieMadeira();
      
    }


  }

  

  cadastrar() {


    console.log(this.especieMadeira);

    this.ativarEspera();
    this.especieMadeiraService.cadastrar(this.especieMadeira)
      .subscribe(

        especieEspecieMadeiraJson => {

          // console.log(especieEspecieMadeiraJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisa-especie-madeira']);


        },
        e => {

          // console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }


      );



  }

  salvar() {

    this.especieMadeiraService.salvar(this.especieMadeira)
      .subscribe(


      );

  }

  deletar() {

    this.especieMadeiraService.deletar(this.especieMadeira)
      .subscribe(


      );

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
