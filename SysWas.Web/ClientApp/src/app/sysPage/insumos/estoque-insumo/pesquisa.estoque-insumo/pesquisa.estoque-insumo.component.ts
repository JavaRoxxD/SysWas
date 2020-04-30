import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, Subscription, interval } from 'rxjs';
import { EstoqueInsumo } from '../../../../model/insumos/estoqueInsumo';
import { EstoqueInsumoService } from '../../../../services/insumos/estoqueInsumo.service';


@Component({
  selector: 'pesquisa-estoque-insumo',
  templateUrl: './pesquisa.estoque-insumo.component.html',
  styleUrls: ['./pesquisa.estoque-insumo.component.css']
})
export class PesquisaEstoqueInsumoComponent implements OnInit {


  // private updateSubscription: Subscription; 
  public estoqueInsumos: EstoqueInsumo[];
  interval: any;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'item', 'quantidade', 'volume', 'editar', 'deletar'];
  dataSource = new MatTableDataSource<EstoqueInsumo>();


  ngOnInit() {

    this.obterTodosEstoqueInsumo();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    sessionStorage.removeItem('estoqueInsumoSession');
    this.interval = setInterval(() => { this.obterTodosEstoqueInsumo() }, 1000);

  }


  constructor(private estoqueInsumoService: EstoqueInsumoService, private router: Router) {

  }

  public obterTodosEstoqueInsumo() {
    this.estoqueInsumoService.obterTodosEstoqueInsumo()
      .subscribe(

        estoqueInsumos => {

          this.estoqueInsumos = estoqueInsumos;
          this.dataSource.data = estoqueInsumos;
          

        },
        e => {

          console.log(e.error);

        });

  }


  public adicionarEstoqueInsumo() {

    this.router.navigate(['/cadastro-estoque-insumo']);

  }

  public editar(estoqueInsumo: EstoqueInsumo) {

    sessionStorage.setItem('estoqueInsumoSession', JSON.stringify(estoqueInsumo));
    this.router.navigate(['/cadastro-estoque-insumo']);

  }

  public deletar(estoqueInsumo: EstoqueInsumo) {


    let retorno = confirm('Deseja realmente deletar esse item?');


    if (retorno == true) {

      this.estoqueInsumoService.deletar(estoqueInsumo).subscribe(
        estoqueInsumos => {
          this.estoqueInsumos = estoqueInsumos;
          this.dataSource.data = estoqueInsumos;

        },
        e => {
          console.log(e.errors);

        }

      );

    }
  }

  // FILTRO DE TABELA
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
    
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }

    
  }


}
