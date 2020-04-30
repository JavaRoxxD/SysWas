import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ControleInsumo } from '../../model/insumos/controleInsumo';




@Injectable({

  providedIn: 'root'

})
export class ControleInsumoService implements OnInit {


  private baseUrl;
  public controleInsumos: ControleInsumo[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.controleInsumos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(controleInsumo: ControleInsumo): Observable<ControleInsumo> {

    return this.http.post<ControleInsumo>(this.baseUrl + 'api/controleInsumo', JSON.stringify(controleInsumo), { headers: this.headers });


  }

  public salvar(controleInsumo: ControleInsumo): Observable<ControleInsumo> {

    return this.http.post<ControleInsumo>(this.baseUrl + 'api/controleInsumo/salvar', JSON.stringify(controleInsumo), { headers: this.headers });


  }

  public deletar(controleInsumo: ControleInsumo): Observable<ControleInsumo[]> {

    return this.http.post<ControleInsumo[]>(this.baseUrl + 'api/controleInsumo/deletar', JSON.stringify(controleInsumo), { headers: this.headers });

  }

  public obterTodosControleInsumo(): Observable<ControleInsumo[]> {

    return this.http.get<ControleInsumo[]>(this.baseUrl + 'api/controleInsumo');

  }

  public obterControleInsumo(produtoId: number): Observable<ControleInsumo> {

    return this.http.get<ControleInsumo>(this.baseUrl + 'api/controleInsumo/obter');

  }



}
