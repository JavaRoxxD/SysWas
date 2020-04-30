import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ControleSaldo } from '../../model/financeiro/controleSaldo';





@Injectable({

  providedIn: 'root'

})
export class ControleSaldoService implements OnInit {


  private baseUrl;
  public controleSaldos: ControleSaldo[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.controleSaldos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(controleSaldo: ControleSaldo): Observable<ControleSaldo> {

    return this.http.post<ControleSaldo>(this.baseUrl + 'api/controleSaldo', JSON.stringify(controleSaldo), { headers: this.headers });


  }

  public salvar(controleSaldo: ControleSaldo): Observable<ControleSaldo> {

    return this.http.post<ControleSaldo>(this.baseUrl + 'api/controleSaldo/salvar', JSON.stringify(controleSaldo), { headers: this.headers });


  }

  public deletar(controleSaldo: ControleSaldo): Observable<ControleSaldo[]> {

    return this.http.post<ControleSaldo[]>(this.baseUrl + 'api/controleSaldo/deletar', JSON.stringify(controleSaldo), { headers: this.headers });

  }

  public obterTodosControleSaldo(): Observable<ControleSaldo[]> {

    return this.http.get<ControleSaldo[]>(this.baseUrl + 'api/controleSaldo');

  }

  public obterControleSaldo(produtoId: number): Observable<ControleSaldo> {

    return this.http.get<ControleSaldo>(this.baseUrl + 'api/controleSaldo/obter');

  }



}
