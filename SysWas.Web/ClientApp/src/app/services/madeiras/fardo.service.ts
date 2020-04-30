import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Fardo } from '../../model/madeiras/fardo';



@Injectable({

  providedIn: 'root'

})
export class FardoService implements OnInit {


  private baseUrl;
  public fardos: Fardo[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.fardos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(fardo: Fardo): Observable<Fardo> {

    return this.http.post<Fardo>(this.baseUrl + 'api/fardo', JSON.stringify(fardo), { headers: this.headers });


  }

  public salvar(fardo: Fardo): Observable<Fardo> {

    return this.http.post<Fardo>(this.baseUrl + 'api/fardo/salvar', JSON.stringify(fardo), { headers: this.headers });


  }

  public deletar(fardo: Fardo): Observable<Fardo[]> {

    return this.http.post<Fardo[]>(this.baseUrl + 'api/fardo/deletar', JSON.stringify(fardo), { headers: this.headers });

  }

  public obterTodosFardo(): Observable<Fardo[]> {

    return this.http.get<Fardo[]>(this.baseUrl + 'api/fardo');

  }

  public obterFardo(produtoId: number): Observable<Fardo> {

    return this.http.get<Fardo>(this.baseUrl + 'api/fardo/obter');

  }



}
