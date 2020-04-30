import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { EspecieMadeira } from '../../model/madeiras/especieMadeira';



@Injectable({

  providedIn: 'root'

})
export class EspecieMadeiraService implements OnInit {


  private baseUrl;
  public especieMadeiras: EspecieMadeira[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.especieMadeiras = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(especieMadeira: EspecieMadeira): Observable<EspecieMadeira> {

    return this.http.post<EspecieMadeira>(this.baseUrl + 'api/especieMadeira', JSON.stringify(especieMadeira), { headers: this.headers });


  }

  public salvar(especieMadeira: EspecieMadeira): Observable<EspecieMadeira> {

    return this.http.post<EspecieMadeira>(this.baseUrl + 'api/especieMadeira/salvar', JSON.stringify(especieMadeira), { headers: this.headers });


  }

  public deletar(especieMadeira: EspecieMadeira): Observable<EspecieMadeira[]> {

    return this.http.post<EspecieMadeira[]>(this.baseUrl + 'api/especieMadeira/deletar', JSON.stringify(especieMadeira), { headers: this.headers });

  }

  public obterTodosEspecieMadeira(): Observable<EspecieMadeira[]> {

    return this.http.get<EspecieMadeira[]>(this.baseUrl + 'api/especieMadeira');

  }

  public obterEspecieMadeira(id: number): Observable<EspecieMadeira> {

    return this.http.post<EspecieMadeira>(this.baseUrl + 'api/especieMadeira/obter', JSON.stringify(id), { headers: this.headers });

  }



}
