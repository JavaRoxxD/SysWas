import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListaBancoEmpresa } from '../../model/financeiro/listaBancoEmpresa';





@Injectable({

  providedIn: 'root'

})
export class ListaBancoEmpresaService implements OnInit {


  private baseUrl;
  public listaBancoEmpresas: ListaBancoEmpresa[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.listaBancoEmpresas = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(listaBancoEmpresa: ListaBancoEmpresa): Observable<ListaBancoEmpresa> {

    return this.http.post<ListaBancoEmpresa>(this.baseUrl + 'api/listaBancoEmpresa', JSON.stringify(listaBancoEmpresa), { headers: this.headers });


  }

  public salvar(listaBancoEmpresa: ListaBancoEmpresa): Observable<ListaBancoEmpresa> {

    return this.http.post<ListaBancoEmpresa>(this.baseUrl + 'api/listaBancoEmpresa/salvar', JSON.stringify(listaBancoEmpresa), { headers: this.headers });


  }

  public deletar(listaBancoEmpresa: ListaBancoEmpresa): Observable<ListaBancoEmpresa[]> {

    return this.http.post<ListaBancoEmpresa[]>(this.baseUrl + 'api/listaBancoEmpresa/deletar', JSON.stringify(listaBancoEmpresa), { headers: this.headers });

  }

  public obterTodosListaBancoEmpresa(): Observable<ListaBancoEmpresa[]> {

    return this.http.get<ListaBancoEmpresa[]>(this.baseUrl + 'api/listaBancoEmpresa');

  }

  public obterListaBancoEmpresa(produtoId: number): Observable<ListaBancoEmpresa> {

    return this.http.get<ListaBancoEmpresa>(this.baseUrl + 'api/listaBancoEmpresa/obter');

  }



}
