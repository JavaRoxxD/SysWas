import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, Subscription, interval } from 'rxjs';
import { ControleInsumo } from '../../../../model/insumos/controleInsumo';
import { ControleInsumoService } from '../../../../services/insumos/controleInsumo.service';


@Component({
  selector: 'pesquisa-controle-insumo',
  templateUrl: './pesquisa.controle-insumo.component.html',
  styleUrls: ['./pesquisa.controle-insumo.component.css']
})
export class PesquisaControleInsumoComponent implements OnInit {


  // private updateSubscription: Subscription;
  public controleInsumos: ControleInsumo[];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'nome', 'quantAlerta', 'volumeAlerta', 'editar', 'deletar'];
  dataSource = new MatTableDataSource<ControleInsumo>();


  ngOnInit() {

    this.obterTodosControleInsumo();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    sessionStorage.removeItem('controleInsumoSession');

  }


  constructor(private controleInsumoService: ControleInsumoService, private router: Router) {

  }

  public obterTodosControleInsumo() {
    this.controleInsumoService.obterTodosControleInsumo()
      .subscribe(

        controleInsumos => {

          this.controleInsumos = controleInsumos;
          this.dataSource.data = controleInsumos;

        },
        e => {

          console.log(e.error);

        });

  }


  public adicionarControleInsumo() {

    this.router.navigate(['/cadastro-controle-insumo']);

  }

  public editar(controleInsumo: ControleInsumo) {

    sessionStorage.setItem('controleInsumoSession', JSON.stringify(controleInsumo));
    this.router.navigate(['/cadastro-controle-insumo']);

  }

  public deletar(controleInsumo: ControleInsumo) {


    let retorno = confirm('Deseja realmente deletar esse item?');


    if (retorno == true) {

      this.controleInsumoService.deletar(controleInsumo).subscribe(
        controleInsumos => {
          this.controleInsumos = controleInsumos;
          this.dataSource.data = controleInsumos;

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
