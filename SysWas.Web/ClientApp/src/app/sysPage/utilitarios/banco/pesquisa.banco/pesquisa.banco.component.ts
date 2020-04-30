import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, Subscription, interval } from 'rxjs';
import { Banco } from '../../../../model/utilitarios/banco';
import { BancoService } from '../../../../services/utilitarios/banco.service';


@Component({
  selector: 'pesquisa-banco',
  templateUrl: './pesquisa.banco.component.html',
  styleUrls: ['./pesquisa.banco.component.css']
})
export class PesquisaBancoComponent implements OnInit {


  // private updateSubscription: Subscription;
  public bancos: Banco[];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'nome'];
  dataSource = new MatTableDataSource<Banco>();


  ngOnInit() {

    this.obterTodosBanco();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    sessionStorage.removeItem('bancoSession');

  }


  constructor(private bancoService: BancoService, private router: Router) {

  }

  public obterTodosBanco() {
    this.bancoService.obterTodosBanco()
      .subscribe(

        bancos => {

          this.bancos = bancos;
          this.dataSource.data = bancos;

        },
        e => {

          console.log(e.error);

        });

  }


  public adicionarBanco() {

    this.router.navigate(['/banco']);

  }

  public editar(banco: Banco) {

    sessionStorage.setItem('bancoSession', JSON.stringify(banco));
    this.router.navigate(['/banco']);

  }

  public deletar(banco: Banco) {


    let retorno = confirm('Deseja realmente deletar esse item?');


    if (retorno == true) {

      this.bancoService.deletar(banco).subscribe(
        bancos => {
          this.bancos = bancos;
          this.dataSource.data = bancos;

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
