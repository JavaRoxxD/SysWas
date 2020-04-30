import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListaMadeira } from '../../model/compras/listaMadeira';





@Injectable({

  providedIn: 'root'

})
export class ListaMadeiraService implements OnInit {


  private baseUrl;
  public listaMadeiras: ListaMadeira[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.listaMadeiras = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(listaMadeira: ListaMadeira): Observable<ListaMadeira> {

    return this.http.post<ListaMadeira>(this.baseUrl + 'api/listaMadeira', JSON.stringify(listaMadeira), { headers: this.headers });


  }

  public salvar(listaMadeira: ListaMadeira): Observable<ListaMadeira> {

    return this.http.post<ListaMadeira>(this.baseUrl + 'api/listaMadeira/salvar', JSON.stringify(listaMadeira), { headers: this.headers });


  }

  public deletar(listaMadeira: ListaMadeira): Observable<ListaMadeira[]> {

    return this.http.post<ListaMadeira[]>(this.baseUrl + 'api/listaMadeira/deletar', JSON.stringify(listaMadeira), { headers: this.headers });

  }

  public obterTodosListaMadeira(): Observable<ListaMadeira[]> {

    return this.http.get<ListaMadeira[]>(this.baseUrl + 'api/listaMadeira');

  }

  public obterListaMadeira(produtoId: number): Observable<ListaMadeira> {

    return this.http.get<ListaMadeira>(this.baseUrl + 'api/listaMadeira/obter');

  }



}
