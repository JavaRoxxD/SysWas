import { Component, OnInit, ViewChild } from '@angular/core';

import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatInput } from '@angular/material';
import { stringify } from '@angular/compiler/src/util';
import { TipoMadeiraService } from '../../../../services/madeiras/tipoMadeira.service';
import { TipoMadeira } from '../../../../model/madeiras/tipoMadeira';


@Component({
  selector: 'cadastro-tipo-madeira',
  templateUrl: './cadastro.tipo-madeira.component.html',
  styleUrls: ['./cadastro.tipo-madeira.component.css']
})
export class CadastroTipoMadeiraComponent implements OnInit {


  // public tipo: TipoTipoMadeira;
  // public tipo: TipoTipoMadeira;
  // public controle: ControleTipoMadeira;



  constructor(
    private tipoMadeiraService: TipoMadeiraService,
    private router: Router
  ) { }

  public tipoMadeira: TipoMadeira;

  public mensagem: string;
  private ativar_spinner: boolean;
  public arquivoSelecionado: File;

  // descricaoFc = new FormControl('', [Validators.required, Validators.minLength(10)]);
  tipoFc = new FormControl('', [Validators.required]);




  ngOnInit() {



    let tipoMadeiraSession = sessionStorage.getItem('tipoMadeiraSession');
    if (tipoMadeiraSession) {

      this.tipoMadeira = JSON.parse(tipoMadeiraSession);

    } else {
      this.tipoMadeira = new TipoMadeira();

    }


  }



  cadastrar() {


    console.log(this.tipoMadeira);

    this.ativarEspera();
    this.tipoMadeiraService.cadastrar(this.tipoMadeira)
      .subscribe(

        tipoTipoMadeiraJson => {

          // console.log(tipoTipoMadeiraJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisa-tipo-madeira']);


        },
        e => {

          // console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }


      );



  }

  salvar() {

    this.tipoMadeiraService.salvar(this.tipoMadeira)
      .subscribe(


      );

  }

  deletar() {

    this.tipoMadeiraService.deletar(this.tipoMadeira)
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
