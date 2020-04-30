import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, Subscription, interval } from 'rxjs';
import { Lote } from '../../../../model/madeiras/lote';
import { LoteService } from '../../../../services/madeiras/lote.service';


@Component({
  selector: 'pesquisa-lote',
  templateUrl: './pesquisa.lote.component.html',
  styleUrls: ['./pesquisa.lote.component.css']
})
export class PesquisaLoteComponent implements OnInit {


  // private updateSubscription: Subscription;
  public lotes: Lote[];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'quantidade', 'descricao', 'baixa', 'pedido', 'imagem', 'editar', 'deletar'];
  dataSource = new MatTableDataSource<Lote>();


  ngOnInit() {

    this.obterTodosLote();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    sessionStorage.removeItem('loteSession');

  }


  constructor(private loteService: LoteService, private router: Router) {

  }

  public obterTodosLote() {
    this.loteService.obterTodosLote()
      .subscribe(

        lotes => {

          this.lotes = lotes;
          this.dataSource.data = lotes;

        },
        e => {

          console.log(e.error);

        });

  }


  public adicionarLote() {

    this.router.navigate(['/lote']);

  }

  public editar(lote: Lote) {

    sessionStorage.setItem('loteSession', JSON.stringify(lote));
    this.router.navigate(['/lote']);

  }

  public deletar(lote: Lote) {


    let retorno = confirm('Deseja realmente deletar esse item?');


    if (retorno == true) {

      this.loteService.deletar(lote).subscribe(
        lotes => {
          this.lotes = lotes;
          this.dataSource.data = lotes;

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
