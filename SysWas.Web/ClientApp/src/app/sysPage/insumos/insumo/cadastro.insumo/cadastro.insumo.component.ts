import { Component, OnInit, ViewChild } from '@angular/core';
import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Insumo } from '../../../../model/insumos/insumo';
import { InsumoService } from '../../../../services/insumos/insumo.service';
import { TipoInsumo } from '../../../../model/insumos/tipoInsumo';
import { ControleInsumo } from '../../../../model/insumos/controleInsumo';
import { TipoInsumoService } from '../../../../services/insumos/tipoInsumo.service';
import { ControleInsumoService } from '../../../../services/insumos/controleInsumo.service';



@Component({
  selector: 'cadastro-insumo',
  templateUrl: './cadastro.insumo.component.html',
  styleUrls: ['./cadastro.insumo.component.css']
})
export class CadastroInsumoComponent implements OnInit {


  constructor(private insumoService: InsumoService,
    private tipoInsumoService: TipoInsumoService,
    private controleInsumoService: ControleInsumoService,
    private router: Router) { }

  public insumo: Insumo;
  public insumoReturn: Insumo;
  public tipos: TipoInsumo[];
  public controles: ControleInsumo[];
  public selectedTipo: TipoInsumo;
  public selectedControle: ControleInsumo;

  public mensagem: string;
  private ativar_spinner: boolean;
  public arquivoSelecionado: File;

  // descricaoFc = new FormControl('', [Validators.required, Validators.minLength(10)]);
  
  nomeFc = new FormControl('', [Validators.required]);
  tipoFc = new FormControl('', [Validators.required]);
  controleFc = new FormControl('', [Validators.required]);
  descricaoFc = new FormControl('', [Validators.required]);



  ngOnInit() {

    this.obterTodosTipo();
    this.obterTodosControle();


    let insumoSession = sessionStorage.getItem('insumoSession');
    if (insumoSession) {

      this.insumo = JSON.parse(insumoSession);
      this.selectedTipo = this.insumo.tipo;
      this.selectedControle = this.insumo.controle;

    } else {
      this.insumo = new Insumo();
      this.selectedTipo = this.insumo.tipo;
      this.selectedControle = this.insumo.controle;

    }


  }

  

  cadastrar() {


    this.insumo.tipoId = this.selectedTipo.id;
    this.insumo.controleId = this.selectedControle.id;


    this.insumo.tipo = this.selectedTipo;
    this.insumo.controle = this.selectedControle;


    console.log(this.insumo);

    this.ativarEspera();
    this.insumoService.cadastrar(this.insumo)
      .subscribe(

        insumoJson => {

          // console.log(insumoJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisa-insumo']);


        },
        e => {

          // console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }


      );



  }

  salvar() {

    this.insumoService.salvar(this.insumo)
      .subscribe(


      );

  }

  deletar() {

    this.insumoService.deletar(this.insumo)
      .subscribe(


      );

  }

  obterTodosInsumo() {

    this.insumoService.obterTodosInsumo()
      .subscribe(


      );

  }

  obterInsumo(id: number) {

    this.insumoService.obterInsumo(id)
      .subscribe(


      );

  }

  obterTodosTipo() {
    this.tipoInsumoService.obterTodosTipoInsumo()
      .subscribe(

        tipos => {

          this.tipos = tipos;


        },
        e => {

          console.log(e.error);

        });

  }

  
  obterTodosControle() {
    this.controleInsumoService.obterTodosControleInsumo()
      .subscribe(

        controles => {

          this.controles = controles;


        },
        e => {

          console.log(e.error);

        });

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
