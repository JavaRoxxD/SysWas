import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListaInsumo } from '../../model/compras/listaInsumo';





@Injectable({

  providedIn: 'root'

})
export class ListaInsumoService implements OnInit {


  private baseUrl;
  public listaInsumos: ListaInsumo[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.listaInsumos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(listaInsumo: ListaInsumo): Observable<ListaInsumo> {

    return this.http.post<ListaInsumo>(this.baseUrl + 'api/listaInsumo', JSON.stringify(listaInsumo), { headers: this.headers });


  }

  public salvar(listaInsumo: ListaInsumo): Observable<ListaInsumo> {

    return this.http.post<ListaInsumo>(this.baseUrl + 'api/listaInsumo/salvar', JSON.stringify(listaInsumo), { headers: this.headers });


  }

  public deletar(listaInsumo: ListaInsumo): Observable<ListaInsumo[]> {

    return this.http.post<ListaInsumo[]>(this.baseUrl + 'api/listaInsumo/deletar', JSON.stringify(listaInsumo), { headers: this.headers });

  }

  public obterTodosListaInsumo(): Observable<ListaInsumo[]> {

    return this.http.get<ListaInsumo[]>(this.baseUrl + 'api/listaInsumo');

  }

  public obterListaInsumo(produtoId: number): Observable<ListaInsumo> {

    return this.http.get<ListaInsumo>(this.baseUrl + 'api/listaInsumo/obter');

  }



}
