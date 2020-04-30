import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, Subscription, interval } from 'rxjs';
import { TipoMadeira } from '../../../../model/madeiras/tipoMadeira';
import { TipoMadeiraService } from '../../../../services/madeiras/tipoMadeira.service';


@Component({
  selector: 'pesquisa-tipo-madeira',
  templateUrl: './pesquisa.tipo-madeira.component.html',
  styleUrls: ['./pesquisa.tipo-madeira.component.css']
})
export class PesquisaTipoMadeiraComponent implements OnInit {


  // private updateSubscription: Subscription;
  public tipoMadeiras: TipoMadeira[];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'tipo', 'editar', 'deletar'];
  dataSource = new MatTableDataSource<TipoMadeira>();


  ngOnInit() {

    this.obterTodosTipoMadeira();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    sessionStorage.removeItem('tipoMadeiraSession');

  }


  constructor(private tipoMadeiraService: TipoMadeiraService, private router: Router) {

  }

  public obterTodosTipoMadeira() {
    this.tipoMadeiraService.obterTodosTipoMadeira()
      .subscribe(

        tipoMadeiras => {

          this.tipoMadeiras = tipoMadeiras;
          this.dataSource.data = tipoMadeiras;

        },
        e => {

          console.log(e.error);

        });

  }


  public adicionarTipoMadeira() {

    this.router.navigate(['/cadastro-tipo-madeira']);

  }

  public editar(tipoMadeira: TipoMadeira) {

    sessionStorage.setItem('tipoMadeiraSession', JSON.stringify(tipoMadeira));
    this.router.navigate(['/cadastro-tipo-madeira']);

  }

  public deletar(tipoMadeira: TipoMadeira) {


    let retorno = confirm('Deseja realmente deletar esse item?');


    if (retorno == true) {

      this.tipoMadeiraService.deletar(tipoMadeira).subscribe(
        tipoMadeiras => {
          this.tipoMadeiras = tipoMadeiras;
          this.dataSource.data = tipoMadeiras;

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

