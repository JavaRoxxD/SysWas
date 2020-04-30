import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Estado } from '../../model/cep/estado';





@Injectable({

  providedIn: 'root'

})
export class EstadoService implements OnInit {


  private baseUrl;
  public estados: Estado[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.estados = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(estado: Estado): Observable<Estado> {

    return this.http.post<Estado>(this.baseUrl + 'api/estado', JSON.stringify(estado), { headers: this.headers });


  }

  public salvar(estado: Estado): Observable<Estado> {

    return this.http.post<Estado>(this.baseUrl + 'api/estado/salvar', JSON.stringify(estado), { headers: this.headers });


  }

  public deletar(estado: Estado): Observable<Estado[]> {

    return this.http.post<Estado[]>(this.baseUrl + 'api/estado/deletar', JSON.stringify(estado), { headers: this.headers });

  }

  public obterTodosEstado(): Observable<Estado[]> {

    return this.http.get<Estado[]>(this.baseUrl + 'api/estado');

  }

  public obterEstado(produtoId: number): Observable<Estado> {

    return this.http.get<Estado>(this.baseUrl + 'api/estado/obter');

  }



}
