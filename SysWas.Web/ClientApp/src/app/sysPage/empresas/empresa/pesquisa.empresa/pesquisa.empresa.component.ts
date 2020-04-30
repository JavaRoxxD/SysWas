import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { Empresa } from '../../../../model/empresas/empresa';
import { EmpresaService } from '../../../../services/empresas/empresa.service';
import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, Subscription, interval } from 'rxjs';
@Component({
  selector: 'pesquisa-empresa',
  templateUrl: './pesquisa.empresa.component.html',
  styleUrls: ['./pesquisa.empresa.component.css']
})
export class PesquisaEmpresaComponent implements OnInit {


  // private updateSubscription: Subscription;
  public empresas: Empresa[];
  interval: any;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'cnpj', 'nomeFantasia', 'endereco', 'numeroEndereco', 'observacao', 'editar', 'deletar'];
  dataSource = new MatTableDataSource<Empresa>();


  ngOnInit() {

    this.obterTodosEmpresa();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    sessionStorage.removeItem('empresaSession');
    this.interval = setInterval(() => { this.obterTodosEmpresa() }, 1000);

  }


  constructor(private empresaService: EmpresaService, private router: Router) {

  }

  public obterTodosEmpresa() {
    this.empresaService.obterTodosEmpresa()
      .subscribe(

        empresas => {

          this.empresas = empresas;
          this.dataSource.data = empresas;



        },
        e => {

          console.log(e.error);

        });

  }


  public adicionarEmpresa() {

    this.router.navigate(['/cadastro-empresa']);

  }

  public editar(empresa: Empresa) {

    sessionStorage.setItem('empresaSession', JSON.stringify(empresa));
    this.router.navigate(['/cadastro-empresa']);

  }

  public deletar(empresa: Empresa) {


    let retorno = confirm('Deseja realmente deletar esse item?');


    if (retorno == true) {

      this.empresaService.deletar(empresa).subscribe(
        empresas => {
          this.empresas = empresas;
          this.dataSource.data = empresas;

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
