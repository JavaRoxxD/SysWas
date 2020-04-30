import { Component, OnInit, ViewChild } from '@angular/core';

import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatInput } from '@angular/material';
import { stringify } from '@angular/compiler/src/util';
import { ControleInsumoService } from '../../../../services/insumos/controleInsumo.service';
import { ControleInsumo } from '../../../../model/insumos/controleInsumo';



@Component({
  selector: 'cadastro-controle-insumo',
  templateUrl: './cadastro.controle-insumo.component.html',
  styleUrls: ['./cadastro.controle-insumo.component.css']
})
export class CadastroControleInsumoComponent implements OnInit {

  constructor(
    private controleInsumoService: ControleInsumoService,
    private router: Router
  ) { }

  public controleInsumo: ControleInsumo;

  public mensagem: string;
  private ativar_spinner: boolean;
  public arquivoSelecionado: File;

  nomeFc = new FormControl('', [Validators.required]);
  quantAlertaFc = new FormControl('', [Validators.required]);
  volumeAlertaFc = new FormControl('', [Validators.required]);



  ngOnInit() {



    let controleInsumoSession = sessionStorage.getItem('controleInsumoSession');
    if (controleInsumoSession) {

      this.controleInsumo = JSON.parse(controleInsumoSession);

    } else {
      this.controleInsumo = new ControleInsumo();

    }


  }



  cadastrar() {


    console.log(this.controleInsumo);

    this.controleInsumo.ativo = true;
    this.ativarEspera();
    this.controleInsumoService.cadastrar(this.controleInsumo)
      .subscribe(

        especieControleInsumoJson => {

          // console.log(especieControleInsumoJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisa-controle-insumo']);


        },
        e => {

          // console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }


      );



  }

  salvar() {

    this.controleInsumoService.salvar(this.controleInsumo)
      .subscribe(


      );

  }

  deletar() {

    this.controleInsumoService.deletar(this.controleInsumo)
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
