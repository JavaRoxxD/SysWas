import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { Madeira } from '../../../../model/madeiras/madeira';
import { MadeiraService } from '../../../../services/madeiras/madeira.service';
import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, Subscription, interval } from 'rxjs';


@Component({
  selector: 'pesquisa-madeira',
  templateUrl: './pesquisa.madeira.component.html',
  styleUrls: ['./pesquisa.madeira.component.css']
})
export class PesquisaMadeiraComponent implements OnInit {


  // private updateSubscription: Subscription;
  public madeiras: Madeira[];
  interval: any;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'descricao', 'espessura', 'largura', 'comprimento', 'preBenef', 'tipo', 'especie', 'controle', 'editar', 'deletar'];
  dataSource = new MatTableDataSource<Madeira>();


  ngOnInit() {

    this.obterTodosMadeira();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    sessionStorage.removeItem('madeiraSession');
    this.interval = setInterval(() => { this.obterTodosMadeira() }, 1000);

  }


  constructor(private madeiraService: MadeiraService, private router: Router) {

  }

  public obterTodosMadeira() {
    this.madeiraService.obterTodosMadeira()
      .subscribe(

        madeiras => {

          this.madeiras = madeiras;
          this.dataSource.data = madeiras;

        },
        e => {

          console.log(e.error);

        });

  }


  public adicionarMadeira() {

    this.router.navigate(['/madeira']);

  }

  public editar(madeira: Madeira) {

    sessionStorage.setItem('madeiraSession', JSON.stringify(madeira));
    this.router.navigate(['/madeira']);

  }

  public deletar(madeira: Madeira) {


    let retorno = confirm('Deseja realmente deletar esse item?');


    if (retorno == true) {

      this.madeiraService.deletar(madeira).subscribe(
        madeiras => {
          this.madeiras = madeiras;
          this.dataSource.data = madeiras;

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
