import { Component, OnInit, ViewChild } from '@angular/core';

import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatInput } from '@angular/material';
import { stringify } from '@angular/compiler/src/util';
import { ControleMadeiraService } from '../../../../services/madeiras/controleMadeira.service';
import { ControleMadeira } from '../../../../model/madeiras/controleMadeira';



@Component({
  selector: 'cadastro-controle-madeira',
  templateUrl: './cadastro.controle-madeira.component.html',
  styleUrls: ['./cadastro.controle-madeira.component.css']
})
export class CadastroControleMadeiraComponent implements OnInit {


  // public tipo: TipoControleMadeira;
  // public especie: EspecieControleMadeira;
  // public controle: ControleControleMadeira;



  constructor(
    private controleMadeiraService: ControleMadeiraService,
    private router: Router
  ) { }

  public controleMadeira: ControleMadeira;

  public mensagem: string;
  private ativar_spinner: boolean;
  public arquivoSelecionado: File;

  // descricaoFc = new FormControl('', [Validators.required, Validators.minLength(10)]);
  nomeFc = new FormControl('', [Validators.required]);
  quantAlertaFc = new FormControl('', [Validators.required]);
  volumeAlertaFc = new FormControl('', [Validators.required]);



  ngOnInit() {



    let controleMadeiraSession = sessionStorage.getItem('controleMadeiraSession');
    if (controleMadeiraSession) {

      this.controleMadeira = JSON.parse(controleMadeiraSession);

    } else {
      this.controleMadeira = new ControleMadeira();

    }


  }



  cadastrar() {


    console.log(this.controleMadeira);

    this.ativarEspera();
    this.controleMadeiraService.cadastrar(this.controleMadeira)
      .subscribe(

        especieControleMadeiraJson => {

          // console.log(especieControleMadeiraJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisa-controle-madeira']);


        },
        e => {

          // console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }


      );



  }

  salvar() {

    this.controleMadeiraService.salvar(this.controleMadeira)
      .subscribe(


      );

  }

  deletar() {

    this.controleMadeiraService.deletar(this.controleMadeira)
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
