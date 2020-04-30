import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cidade } from '../../model/cep/cidade';





@Injectable({

  providedIn: 'root'

})
export class CidadeService implements OnInit {


  private baseUrl;
  public cidades: Cidade[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.cidades = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(cidade: Cidade): Observable<Cidade> {

    return this.http.post<Cidade>(this.baseUrl + 'api/cidade', JSON.stringify(cidade), { headers: this.headers });


  }

  public salvar(cidade: Cidade): Observable<Cidade> {

    return this.http.post<Cidade>(this.baseUrl + 'api/cidade/salvar', JSON.stringify(cidade), { headers: this.headers });


  }

  public deletar(cidade: Cidade): Observable<Cidade[]> {

    return this.http.post<Cidade[]>(this.baseUrl + 'api/cidade/deletar', JSON.stringify(cidade), { headers: this.headers });

  }

  public obterTodosCidade(estado: number): Observable<Cidade[]> {

    return this.http.post<Cidade[]>(this.baseUrl + 'api/cidade/VerificarEstado', JSON.stringify(estado), { headers: this.headers });

  }

  public obterCidade(produtoId: number): Observable<Cidade> {

    return this.http.get<Cidade>(this.baseUrl + 'api/cidade/obter');

  }



}
