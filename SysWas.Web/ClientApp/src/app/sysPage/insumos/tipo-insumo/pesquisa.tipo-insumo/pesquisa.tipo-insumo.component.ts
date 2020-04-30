import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, Subscription, interval } from 'rxjs';
import { TipoInsumo } from '../../../../model/insumos/tipoInsumo';
import { TipoInsumoService } from '../../../../services/insumos/tipoInsumo.service';


@Component({
  selector: 'pesquisa-tipo-insumo',
  templateUrl: './pesquisa.tipo-insumo.component.html',
  styleUrls: ['./pesquisa.tipo-insumo.component.css']
})
export class PesquisaTipoInsumoComponent implements OnInit {


  // private updateSubscription: Subscription;
  public tipoInsumos: TipoInsumo[];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'tipo', 'editar', 'deletar'];
  dataSource = new MatTableDataSource<TipoInsumo>();


  ngOnInit() {

    this.obterTodosTipoInsumo();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    sessionStorage.removeItem('tipoInsumoSession');

  }


  constructor(private tipoInsumoService: TipoInsumoService, private router: Router) {

  }

  public obterTodosTipoInsumo() {
    this.tipoInsumoService.obterTodosTipoInsumo()
      .subscribe(

        tipoInsumos => {

          this.tipoInsumos = tipoInsumos;
          this.dataSource.data = tipoInsumos;

        },
        e => {

          console.log(e.error);

        });

  }


  public adicionarTipoInsumo() {

    this.router.navigate(['/cadastro-tipo-insumo']);

  }

  public editar(tipoInsumo: TipoInsumo) {

    sessionStorage.setItem('tipoInsumoSession', JSON.stringify(tipoInsumo));
    this.router.navigate(['/cadastro-tipo-insumo']);

  }

  public deletar(tipoInsumo: TipoInsumo) {


    let retorno = confirm('Deseja realmente deletar esse item?');


    if (retorno == true) {

      this.tipoInsumoService.deletar(tipoInsumo).subscribe(
        tipoInsumos => {
          this.tipoInsumos = tipoInsumos;
          this.dataSource.data = tipoInsumos;

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

