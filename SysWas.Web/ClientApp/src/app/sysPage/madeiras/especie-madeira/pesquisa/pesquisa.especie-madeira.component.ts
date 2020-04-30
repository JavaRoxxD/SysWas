import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, Subscription, interval } from 'rxjs';
import { EspecieMadeira } from '../../../../model/madeiras/especieMadeira';
import { EspecieMadeiraService } from '../../../../services/madeiras/especieMadeira.service';


@Component({
  selector: 'pesquisa-especie-madeira',
  templateUrl: './pesquisa.especie-madeira.component.html',
  styleUrls: ['./pesquisa.especie-madeira.component.css']
})
export class PesquisaEspecieMadeiraComponent implements OnInit {


  // private updateSubscription: Subscription;
  public especieMadeiras: EspecieMadeira[];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'especie','editar', 'deletar'];
  dataSource = new MatTableDataSource<EspecieMadeira>();


  ngOnInit() {

    this.obterTodosEspecieMadeira();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    sessionStorage.removeItem('especieMadeiraSession');

  }


  constructor(private especieMadeiraService: EspecieMadeiraService, private router: Router) {

  }

  public obterTodosEspecieMadeira() {
    this.especieMadeiraService.obterTodosEspecieMadeira()
      .subscribe(

        especieMadeiras => {

          this.especieMadeiras = especieMadeiras;
          this.dataSource.data = especieMadeiras;

        },
        e => {

          console.log(e.error);

        });

  }


  public adicionarEspecieMadeira() {

    this.router.navigate(['/cadastro-especie-madeira']);

  }

  public editar(especieMadeira: EspecieMadeira) {

    sessionStorage.setItem('especieMadeiraSession', JSON.stringify(especieMadeira));
    this.router.navigate(['/cadastro-especie-madeira']);

  }

  public deletar(especieMadeira: EspecieMadeira) {


    let retorno = confirm('Deseja realmente deletar esse item?');


    if (retorno == true) {

      this.especieMadeiraService.deletar(especieMadeira).subscribe(
        especieMadeiras => {
          this.especieMadeiras = especieMadeiras;
          this.dataSource.data = especieMadeiras;

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
