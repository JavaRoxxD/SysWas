import { Component, OnInit, ViewChild } from '@angular/core';

import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatInput } from '@angular/material';
import { stringify } from '@angular/compiler/src/util';
import { TipoInsumoService } from '../../../../services/insumos/tipoInsumo.service';
import { TipoInsumo } from '../../../../model/insumos/tipoInsumo';


@Component({
  selector: 'cadastro-tipo-insumo',
  templateUrl: './cadastro.tipo-insumo.component.html',
  styleUrls: ['./cadastro.tipo-insumo.component.css']
})
export class CadastroTipoInsumoComponent implements OnInit {


  // public tipo: TipoTipoInsumo;
  // public tipo: TipoTipoInsumo;
  // public controle: ControleTipoInsumo;



  constructor(
    private tipoInsumoService: TipoInsumoService,
    private router: Router
  ) { }

  public tipoInsumo: TipoInsumo;

  public mensagem: string;
  private ativar_spinner: boolean;
  public arquivoSelecionado: File;

  // descricaoFc = new FormControl('', [Validators.required, Validators.minLength(10)]);
  tipoFc = new FormControl('', [Validators.required]);




  ngOnInit() {



    let tipoInsumoSession = sessionStorage.getItem('tipoInsumoSession');
    if (tipoInsumoSession) {

      this.tipoInsumo = JSON.parse(tipoInsumoSession);

    } else {
      this.tipoInsumo = new TipoInsumo();

    }


  }



  cadastrar() {


    console.log(this.tipoInsumo);

    this.ativarEspera();
    this.tipoInsumoService.cadastrar(this.tipoInsumo)
      .subscribe(

        tipoTipoInsumoJson => {

          // console.log(tipoTipoInsumoJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisa-tipo-insumo']);


        },
        e => {

          // console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }


      );



  }

  salvar() {

    this.tipoInsumoService.salvar(this.tipoInsumo)
      .subscribe(


      );

  }

  deletar() {

    this.tipoInsumoService.deletar(this.tipoInsumo)
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
