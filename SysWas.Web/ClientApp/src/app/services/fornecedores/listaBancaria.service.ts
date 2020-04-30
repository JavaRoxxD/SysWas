import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListaBancaria } from '../../model/Fornecedores/listaBancaria';





@Injectable({

  providedIn: 'root'

})
export class ListaBancariaService implements OnInit {


  private baseUrl;
  public listaBancarias: ListaBancaria[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.listaBancarias = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(listaBancaria: ListaBancaria): Observable<ListaBancaria> {

    return this.http.post<ListaBancaria>(this.baseUrl + 'api/listaBancaria', JSON.stringify(listaBancaria), { headers: this.headers });


  }

  public salvar(listaBancaria: ListaBancaria): Observable<ListaBancaria> {

    return this.http.post<ListaBancaria>(this.baseUrl + 'api/listaBancaria/salvar', JSON.stringify(listaBancaria), { headers: this.headers });


  }

  public deletar(listaBancaria: ListaBancaria): Observable<ListaBancaria[]> {

    return this.http.post<ListaBancaria[]>(this.baseUrl + 'api/listaBancaria/deletar', JSON.stringify(listaBancaria), { headers: this.headers });

  }

  public obterTodosListaBancaria(): Observable<ListaBancaria[]> {

    return this.http.get<ListaBancaria[]>(this.baseUrl + 'api/listaBancaria');

  }

  public obterListaBancaria(produtoId: number): Observable<ListaBancaria> {

    return this.http.get<ListaBancaria>(this.baseUrl + 'api/listaBancaria/obter');

  }



}
