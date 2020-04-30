import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoInsumo } from '../../model/insumos/tipoInsumo';




@Injectable({

  providedIn: 'root'

})
export class TipoInsumoService implements OnInit {


  private baseUrl;
  public tipoInsumos: TipoInsumo[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.tipoInsumos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(tipoInsumo: TipoInsumo): Observable<TipoInsumo> {

    return this.http.post<TipoInsumo>(this.baseUrl + 'api/tipoInsumo', JSON.stringify(tipoInsumo), { headers: this.headers });


  }

  public salvar(tipoInsumo: TipoInsumo): Observable<TipoInsumo> {

    return this.http.post<TipoInsumo>(this.baseUrl + 'api/tipoInsumo/salvar', JSON.stringify(tipoInsumo), { headers: this.headers });


  }

  public deletar(tipoInsumo: TipoInsumo): Observable<TipoInsumo[]> {

    return this.http.post<TipoInsumo[]>(this.baseUrl + 'api/tipoInsumo/deletar', JSON.stringify(tipoInsumo), { headers: this.headers });

  }

  public obterTodosTipoInsumo(): Observable<TipoInsumo[]> {

    return this.http.get<TipoInsumo[]>(this.baseUrl + 'api/tipoInsumo');

  }

  public obterTipoInsumo(produtoId: number): Observable<TipoInsumo> {

    return this.http.get<TipoInsumo>(this.baseUrl + 'api/tipoInsumo/obter');

  }



}
