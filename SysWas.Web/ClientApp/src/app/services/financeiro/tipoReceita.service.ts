import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoReceita } from '../../model/financeiro/tipoReceita';





@Injectable({

  providedIn: 'root'

})
export class TipoReceitaService implements OnInit {


  private baseUrl;
  public tipoReceitas: TipoReceita[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.tipoReceitas = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(tipoReceita: TipoReceita): Observable<TipoReceita> {

    return this.http.post<TipoReceita>(this.baseUrl + 'api/tipoReceita', JSON.stringify(tipoReceita), { headers: this.headers });


  }

  public salvar(tipoReceita: TipoReceita): Observable<TipoReceita> {

    return this.http.post<TipoReceita>(this.baseUrl + 'api/tipoReceita/salvar', JSON.stringify(tipoReceita), { headers: this.headers });


  }

  public deletar(tipoReceita: TipoReceita): Observable<TipoReceita[]> {

    return this.http.post<TipoReceita[]>(this.baseUrl + 'api/tipoReceita/deletar', JSON.stringify(tipoReceita), { headers: this.headers });

  }

  public obterTodosTipoReceita(): Observable<TipoReceita[]> {

    return this.http.get<TipoReceita[]>(this.baseUrl + 'api/tipoReceita');

  }

  public obterTipoReceita(produtoId: number): Observable<TipoReceita> {

    return this.http.get<TipoReceita>(this.baseUrl + 'api/tipoReceita/obter');

  }



}
