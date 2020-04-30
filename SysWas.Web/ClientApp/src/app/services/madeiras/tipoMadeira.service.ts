import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { TipoMadeira } from '../../model/madeiras/tipoMadeira';



@Injectable({

  providedIn: 'root'

})
export class TipoMadeiraService implements OnInit {


  private baseUrl;
  public tipoMadeiras: TipoMadeira[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.tipoMadeiras = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(tipoMadeira: TipoMadeira): Observable<TipoMadeira> {

    return this.http.post<TipoMadeira>(this.baseUrl + 'api/tipoMadeira', JSON.stringify(tipoMadeira), { headers: this.headers });


  }

  public salvar(tipoMadeira: TipoMadeira): Observable<TipoMadeira> {

    return this.http.post<TipoMadeira>(this.baseUrl + 'api/tipoMadeira/salvar', JSON.stringify(tipoMadeira), { headers: this.headers });


  }

  public deletar(tipoMadeira: TipoMadeira): Observable<TipoMadeira[]> {

    return this.http.post<TipoMadeira[]>(this.baseUrl + 'api/tipoMadeira/deletar', JSON.stringify(tipoMadeira), { headers: this.headers });

  }

  public obterTodosTipoMadeira(): Observable<TipoMadeira[]> {

    return this.http.get<TipoMadeira[]>(this.baseUrl + 'api/tipoMadeira');

  }

  public obterTipoMadeira(id: number): Observable<TipoMadeira> {

    return this.http.post<TipoMadeira>(this.baseUrl + 'api/tipoMadeira/obter', JSON.stringify(id), { headers: this.headers });

  }



}
