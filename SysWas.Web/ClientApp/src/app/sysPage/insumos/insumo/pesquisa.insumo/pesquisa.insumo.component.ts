import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, Subscription, interval } from 'rxjs';
import { Insumo } from '../../../../model/insumos/insumo';
import { InsumoService } from '../../../../services/insumos/insumo.service';


@Component({
  selector: 'pesquisa-insumo',
  templateUrl: './pesquisa.insumo.component.html',
  styleUrls: ['./pesquisa.insumo.component.css']
})
export class PesquisaInsumoComponent implements OnInit {


  // private updateSubscription: Subscription;
  public insumos: Insumo[];
  interval: any;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'nome', 'tipo', 'controle', 'descricao', 'editar', 'deletar'];
  dataSource = new MatTableDataSource<Insumo>();


  ngOnInit() {

    this.obterTodosInsumo();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    sessionStorage.removeItem('insumoSession');
    this.interval = setInterval(() => { this.obterTodosInsumo() }, 1000);

  }


  constructor(private insumoService: InsumoService, private router: Router) {

  }

  public obterTodosInsumo() {
    this.insumoService.obterTodosInsumo()
      .subscribe(

        insumos => {

          this.insumos = insumos;
          this.dataSource.data = insumos;

        },
        e => {

          console.log(e.error);

        });

  }


  public adicionarInsumo() {

    this.router.navigate(['/cadastro-insumo']);

  }

  public editar(insumo: Insumo) {

    sessionStorage.setItem('insumoSession', JSON.stringify(insumo));
    this.router.navigate(['/insumo']);

  }

  public deletar(insumo: Insumo) {


    let retorno = confirm('Deseja realmente deletar esse item?');


    if (retorno == true) {

      this.insumoService.deletar(insumo).subscribe(
        insumos => {
          this.insumos = insumos;
          this.dataSource.data = insumos;

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
