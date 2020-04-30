import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Despesa } from '../../model/financeiro/despesa';




@Injectable({

  providedIn: 'root'

})
export class DespesaService implements OnInit {


  private baseUrl;
  public despesas: Despesa[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.despesas = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(despesa: Despesa): Observable<Despesa> {

    return this.http.post<Despesa>(this.baseUrl + 'api/despesa', JSON.stringify(despesa), { headers: this.headers });


  }

  public salvar(despesa: Despesa): Observable<Despesa> {

    return this.http.post<Despesa>(this.baseUrl + 'api/despesa/salvar', JSON.stringify(despesa), { headers: this.headers });


  }

  public deletar(despesa: Despesa): Observable<Despesa[]> {

    return this.http.post<Despesa[]>(this.baseUrl + 'api/despesa/deletar', JSON.stringify(despesa), { headers: this.headers });

  }

  public obterTodosDespesa(): Observable<Despesa[]> {

    return this.http.get<Despesa[]>(this.baseUrl + 'api/despesa');

  }

  public obterDespesa(produtoId: number): Observable<Despesa> {

    return this.http.get<Despesa>(this.baseUrl + 'api/despesa/obter');

  }



}
