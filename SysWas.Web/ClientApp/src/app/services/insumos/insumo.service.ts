import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Insumo } from '../../model/insumos/insumo';




@Injectable({

  providedIn: 'root'

})
export class InsumoService implements OnInit {


  private baseUrl;
  public insumos: Insumo[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.insumos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(insumo: Insumo): Observable<Insumo> {

    return this.http.post<Insumo>(this.baseUrl + 'api/insumo', JSON.stringify(insumo), { headers: this.headers });


  }

  public salvar(insumo: Insumo): Observable<Insumo> {

    return this.http.post<Insumo>(this.baseUrl + 'api/insumo/salvar', JSON.stringify(insumo), { headers: this.headers });


  }

  public deletar(insumo: Insumo): Observable<Insumo[]> {

    return this.http.post<Insumo[]>(this.baseUrl + 'api/insumo/deletar', JSON.stringify(insumo), { headers: this.headers });

  }

  public obterTodosInsumo(): Observable<Insumo[]> {

    return this.http.get<Insumo[]>(this.baseUrl + 'api/insumo');

  }

  public obterInsumo(produtoId: number): Observable<Insumo> {

    return this.http.get<Insumo>(this.baseUrl + 'api/insumo/obter');

  }



}
