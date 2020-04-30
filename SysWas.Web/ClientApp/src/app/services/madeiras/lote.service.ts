import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Lote } from '../../model/madeiras/lote';



@Injectable({

  providedIn: 'root'

})
export class LoteService implements OnInit {


  private baseUrl;
  public lotes: Lote[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.lotes = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(lote: Lote): Observable<Lote> {

    return this.http.post<Lote>(this.baseUrl + 'api/lote', JSON.stringify(lote), { headers: this.headers });


  }

  public salvar(lote: Lote): Observable<Lote> {

    return this.http.post<Lote>(this.baseUrl + 'api/lote/salvar', JSON.stringify(lote), { headers: this.headers });


  }

  public deletar(lote: Lote): Observable<Lote[]> {

    return this.http.post<Lote[]>(this.baseUrl + 'api/lote/deletar', JSON.stringify(lote), { headers: this.headers });

  }

  public obterTodosLote(): Observable<Lote[]> {

    return this.http.get<Lote[]>(this.baseUrl + 'api/lote');

  }

  public obterLote(produtoId: number): Observable<Lote> {

    return this.http.get<Lote>(this.baseUrl + 'api/lote/obter');

  }



}
