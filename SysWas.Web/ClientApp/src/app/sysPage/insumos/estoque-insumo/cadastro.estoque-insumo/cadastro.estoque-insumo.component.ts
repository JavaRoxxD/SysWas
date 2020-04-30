import { Component, OnInit, ViewChild } from '@angular/core';

import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatInput } from '@angular/material';
import { stringify } from '@angular/compiler/src/util';
import { EstoqueInsumoService } from '../../../../services/insumos/estoqueInsumo.service';
import { EstoqueInsumo } from '../../../../model/insumos/estoqueInsumo';
import { InsumoService } from '../../../../services/insumos/insumo.service';
import { Insumo } from '../../../../model/insumos/insumo';


@Component({
  selector: 'cadastro-estoque-insumo',
  templateUrl: './cadastro.estoque-insumo.component.html',
  styleUrls: ['./cadastro.estoque-insumo.component.css']
})
export class CadastroEstoqueInsumoComponent implements OnInit {



  public estoqueInsumo: EstoqueInsumo;
  public estoqueInsumoReturn: EstoqueInsumo;
  public itens: Insumo[];
  public selectedItem: Insumo;

  public mensagem: string;
  private ativar_spinner: boolean;

  constructor(
    private estoqueInsumoService: EstoqueInsumoService, private insumoService: InsumoService,
    private router: Router
  ) { }

  
  

  // descricaoFc = new FormControl('', [Validators.required, Validators.minLength(10)]);
  estoqueFc = new FormControl('', [Validators.required]);
  quantidadeFc = new FormControl('', [Validators.required]);
  volumeFc = new FormControl('', [Validators.required]);
  itemFc = new FormControl('', [Validators.required]);


  ngOnInit() {


    this.obterTodosItens();
    let estoqueInsumoSession = sessionStorage.getItem('estoqueInsumoSession');
    if (estoqueInsumoSession) {

      this.estoqueInsumo = JSON.parse(estoqueInsumoSession);

      this.selectedItem = this.estoqueInsumo.item;

    } else {
      this.estoqueInsumo = new EstoqueInsumo();

    }


  }



  cadastrar() {


    this.estoqueInsumo.itemId = this.selectedItem.id;


    this.estoqueInsumo.item = this.selectedItem;


    console.log(this.estoqueInsumo);

    this.ativarEspera();
    this.estoqueInsumoService.cadastrar(this.estoqueInsumo)
      .subscribe(

        estoqueEstoqueInsumoJson => {

          // console.log(estoqueEstoqueInsumoJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisa-estoque-insumo']);


        },
        e => {

          // console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }


      );



  }

  salvar() {

    this.estoqueInsumoService.salvar(this.estoqueInsumo)
      .subscribe(


      );

  }

  deletar() {

    this.estoqueInsumoService.deletar(this.estoqueInsumo)
      .subscribe(


      );

  }


  obterTodosItens() {
    this.insumoService.obterTodosInsumo()
      .subscribe(

        itens => {

          this.itens = itens;


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
