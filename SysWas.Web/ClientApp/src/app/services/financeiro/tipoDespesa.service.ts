import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoDespesa } from '../../model/financeiro/tipoDespesa';





@Injectable({

  providedIn: 'root'

})
export class TipoDespesaService implements OnInit {


  private baseUrl;
  public tipoDespesas: TipoDespesa[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.tipoDespesas = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(tipoDespesa: TipoDespesa): Observable<TipoDespesa> {

    return this.http.post<TipoDespesa>(this.baseUrl + 'api/tipoDespesa', JSON.stringify(tipoDespesa), { headers: this.headers });


  }

  public salvar(tipoDespesa: TipoDespesa): Observable<TipoDespesa> {

    return this.http.post<TipoDespesa>(this.baseUrl + 'api/tipoDespesa/salvar', JSON.stringify(tipoDespesa), { headers: this.headers });


  }

  public deletar(tipoDespesa: TipoDespesa): Observable<TipoDespesa[]> {

    return this.http.post<TipoDespesa[]>(this.baseUrl + 'api/tipoDespesa/deletar', JSON.stringify(tipoDespesa), { headers: this.headers });

  }

  public obterTodosTipoDespesa(): Observable<TipoDespesa[]> {

    return this.http.get<TipoDespesa[]>(this.baseUrl + 'api/tipoDespesa');

  }

  public obterTipoDespesa(produtoId: number): Observable<TipoDespesa> {

    return this.http.get<TipoDespesa>(this.baseUrl + 'api/tipoDespesa/obter');

  }



}
