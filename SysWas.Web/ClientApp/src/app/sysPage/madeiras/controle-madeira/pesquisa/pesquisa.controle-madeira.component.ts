import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, Subscription, interval } from 'rxjs';
import { ControleMadeira } from '../../../../model/madeiras/controleMadeira';
import { ControleMadeiraService } from '../../../../services/madeiras/controleMadeira.service';


@Component({
  selector: 'pesquisa-controle-madeira',
  templateUrl: './pesquisa.controle-madeira.component.html',
  styleUrls: ['./pesquisa.controle-madeira.component.css']
})
export class PesquisaControleMadeiraComponent implements OnInit {


  // private updateSubscription: Subscription;
  public controleMadeiras: ControleMadeira[];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'nome', 'quantAlerta', 'volumeAlerta', 'editar', 'deletar'];
  dataSource = new MatTableDataSource<ControleMadeira>();


  ngOnInit() {

    this.obterTodosControleMadeira();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    sessionStorage.removeItem('controleMadeiraSession');

  }


  constructor(private controleMadeiraService: ControleMadeiraService, private router: Router) {

  }

  public obterTodosControleMadeira() {
    this.controleMadeiraService.obterTodosControleMadeira()
      .subscribe(

        controleMadeiras => {

          this.controleMadeiras = controleMadeiras;
          this.dataSource.data = controleMadeiras;

        },
        e => {

          console.log(e.error);

        });

  }


  public adicionarControleMadeira() {

    this.router.navigate(['/cadastro-controle-madeira']);

  }

  public editar(controleMadeira: ControleMadeira) {

    sessionStorage.setItem('controleMadeiraSession', JSON.stringify(controleMadeira));
    this.router.navigate(['/cadastro-controle-madeira']);

  }

  public deletar(controleMadeira: ControleMadeira) {


    let retorno = confirm('Deseja realmente deletar esse item?');


    if (retorno == true) {

      this.controleMadeiraService.deletar(controleMadeira).subscribe(
        controleMadeiras => {
          this.controleMadeiras = controleMadeiras;
          this.dataSource.data = controleMadeiras;

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
