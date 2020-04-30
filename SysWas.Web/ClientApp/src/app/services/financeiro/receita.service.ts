import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Receita } from '../../model/financeiro/receita';





@Injectable({

  providedIn: 'root'

})
export class ReceitaService implements OnInit {


  private baseUrl;
  public receitas: Receita[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.receitas = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(receita: Receita): Observable<Receita> {

    return this.http.post<Receita>(this.baseUrl + 'api/receita', JSON.stringify(receita), { headers: this.headers });


  }

  public salvar(receita: Receita): Observable<Receita> {

    return this.http.post<Receita>(this.baseUrl + 'api/receita/salvar', JSON.stringify(receita), { headers: this.headers });


  }

  public deletar(receita: Receita): Observable<Receita[]> {

    return this.http.post<Receita[]>(this.baseUrl + 'api/receita/deletar', JSON.stringify(receita), { headers: this.headers });

  }

  public obterTodosReceita(): Observable<Receita[]> {

    return this.http.get<Receita[]>(this.baseUrl + 'api/receita');

  }

  public obterReceita(produtoId: number): Observable<Receita> {

    return this.http.get<Receita>(this.baseUrl + 'api/receita/obter');

  }



}
