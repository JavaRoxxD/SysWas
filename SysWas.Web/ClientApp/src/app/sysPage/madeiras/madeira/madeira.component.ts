import { Component, OnInit, ViewChild } from '@angular/core';
import { MadeiraService } from '../../../services/madeiras/madeira.service';
import { Madeira } from '../../../model/madeiras/madeira';
import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatInput } from '@angular/material';
import { TipoMadeiraService } from '../../../services/madeiras/tipoMadeira.service';
import { EspecieMadeiraService } from '../../../services/madeiras/especieMadeira.service';
import { ControleMadeiraService } from '../../../services/madeiras/controleMadeira.service';
import { stringify } from '@angular/compiler/src/util';
import { TipoMadeira } from '../../../model/madeiras/tipoMadeira';
import { EspecieMadeira } from '../../../model/madeiras/especieMadeira';
import { ControleMadeira } from '../../../model/madeiras/controleMadeira';

@Component({
  selector: 'madeira',
  templateUrl: './madeira.component.html',
  styleUrls: ['./madeira.component.css']
})
export class MadeiraComponent implements OnInit {


  // public tipo: TipoMadeira;
  // public especie: EspecieMadeira;
  // public controle: ControleMadeira;



  constructor(private madeiraService: MadeiraService,
    private tipoMadeiraService: TipoMadeiraService,
    private especieMadeiraService: EspecieMadeiraService,
    private controleMadeiraService: ControleMadeiraService,
    private router: Router) { }

  public madeira: Madeira;
  public madeiraReturn: Madeira;
  public tipos: TipoMadeira[];
  public especies: EspecieMadeira[];
  public controles: ControleMadeira[];
  public selectedTipo: TipoMadeira;
  public selectedEspecie: EspecieMadeira;
  public selectedControle: ControleMadeira;

  public mensagem: string;
  private ativar_spinner: boolean;
  public arquivoSelecionado: File;

  // descricaoFc = new FormControl('', [Validators.required, Validators.minLength(10)]);
  descricaoFc = new FormControl('', [Validators.required]);
  espessuraFc = new FormControl('', [Validators.required]);
  larguraFc = new FormControl('', [Validators.required]);
  comprimentoFc = new FormControl('', [Validators.required]);
  tipoIdFc = new FormControl('', [Validators.required]);
  especieIdFc = new FormControl('', [Validators.required]);
  controleIdFc = new FormControl('', [Validators.required]);



  ngOnInit() {

    this.obterTodosTipo();
    this.obterTodosEspecie();
    this.obterTodosControle();


    let madeiraSession = sessionStorage.getItem('madeiraSession');
    if (madeiraSession) {

      this.madeira = JSON.parse(madeiraSession);
      this.selectedTipo = this.madeira.tipo;
      this.selectedEspecie = this.madeira.especie;
      this.selectedControle = this.madeira.controle;

      // this.tipo = this.madeira.tipo;
      // this.especie = this.madeira.especie;
      // this.controle = this.madeira.controle;

    } else {
      this.madeira = new Madeira();
      this.selectedTipo = this.madeira.tipo;
      this.selectedEspecie = this.madeira.especie;
      this.selectedControle = this.madeira.controle;

    }


  }

  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0);
    this.ativar_spinner = true;
    this.madeiraService.enviarArquivo(this.arquivoSelecionado)
      .subscribe(
        nomeArquivo => {


          this.madeira.espessura = parseInt(nomeArquivo);
          alert(nomeArquivo);
          console.log(nomeArquivo);
          this.ativar_spinner = false;
        },
        e => {
          console.log(e.error);
          this.ativar_spinner = false;
        });


  }

  checkBoxvalue(event, componente: string) {

    // console.log(event);
    // console.log(componente);
    // console.log(this.selectedEspecie.especie);



  }


  cadastrar() {


    this.madeira.tipoId = this.selectedTipo.id;
    this.madeira.especieId = this.selectedEspecie.id;
    this.madeira.controleId = this.selectedControle.id;


    this.madeira.tipo = this.selectedTipo;
    this.madeira.especie = this.selectedEspecie;
    this.madeira.controle = this.selectedControle;


    console.log(this.madeira);

    this.ativarEspera();
    this.madeiraService.cadastrar(this.madeira)
      .subscribe(

        madeiraJson => {

          // console.log(madeiraJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisa-madeira']);


        },
        e => {

          // console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }


    );



  }

  salvar() {

    this.madeiraService.salvar(this.madeira)
      .subscribe(


      );

  }

  deletar() {

    this.madeiraService.deletar(this.madeira)
      .subscribe(


      );

  }

  obterTodosMadeira() {

    this.madeiraService.obterTodosMadeira()
      .subscribe(


      );

  }

  obterMadeira(id: number) {

    this.madeiraService.obterMadeira(id)
      .subscribe(


      );

  }

  obterTodosTipo() {
    this.tipoMadeiraService.obterTodosTipoMadeira()
      .subscribe(

        tipos => {

          this.tipos = tipos;


        },
        e => {

          console.log(e.error);

        });

  }

  obterTodosEspecie() {
    this.especieMadeiraService.obterTodosEspecieMadeira()
      .subscribe(

        especies => {

          this.especies = especies;


        },
        e => {

          console.log(e.error);

        });

  }

  obterTodosControle() {
    this.controleMadeiraService.obterTodosControleMadeira()
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
