import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EstoqueInsumo } from '../../model/insumos/estoqueInsumo';




@Injectable({

  providedIn: 'root'

})
export class EstoqueInsumoService implements OnInit {


  private baseUrl;
  public estoqueInsumos: EstoqueInsumo[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.estoqueInsumos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(estoqueInsumo: EstoqueInsumo): Observable<EstoqueInsumo> {

    return this.http.post<EstoqueInsumo>(this.baseUrl + 'api/estoqueInsumo', JSON.stringify(estoqueInsumo), { headers: this.headers });


  }

  public salvar(estoqueInsumo: EstoqueInsumo): Observable<EstoqueInsumo> {

    return this.http.post<EstoqueInsumo>(this.baseUrl + 'api/estoqueInsumo/salvar', JSON.stringify(estoqueInsumo), { headers: this.headers });


  }

  public deletar(estoqueInsumo: EstoqueInsumo): Observable<EstoqueInsumo[]> {

    return this.http.post<EstoqueInsumo[]>(this.baseUrl + 'api/estoqueInsumo/deletar', JSON.stringify(estoqueInsumo), { headers: this.headers });

  }

  public obterTodosEstoqueInsumo(): Observable<EstoqueInsumo[]> {

    return this.http.get<EstoqueInsumo[]>(this.baseUrl + 'api/estoqueInsumo');

  }

  public obterEstoqueInsumo(produtoId: number): Observable<EstoqueInsumo> {

    return this.http.get<EstoqueInsumo>(this.baseUrl + 'api/estoqueInsumo/obter');

  }



}
