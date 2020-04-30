import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ControleMadeira } from '../../model/madeiras/controleMadeira';



@Injectable({

  providedIn: 'root'

})
export class ControleMadeiraService implements OnInit {


  private baseUrl;
  public controleMadeiras: ControleMadeira[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.controleMadeiras = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(controleMadeira: ControleMadeira): Observable<ControleMadeira> {

    return this.http.post<ControleMadeira>(this.baseUrl + 'api/controleMadeira', JSON.stringify(controleMadeira), { headers: this.headers });


  }

  public salvar(controleMadeira: ControleMadeira): Observable<ControleMadeira> {

    return this.http.post<ControleMadeira>(this.baseUrl + 'api/controleMadeira/salvar', JSON.stringify(controleMadeira), { headers: this.headers });


  }

  public deletar(controleMadeira: ControleMadeira): Observable<ControleMadeira[]> {

    return this.http.post<ControleMadeira[]>(this.baseUrl + 'api/controleMadeira/deletar', JSON.stringify(controleMadeira), { headers: this.headers });

  }

  public obterTodosControleMadeira(): Observable<ControleMadeira[]> {

    return this.http.get<ControleMadeira[]>(this.baseUrl + 'api/controleMadeira');

  }

  public obterControleMadeira(id: number): Observable<ControleMadeira> {

    return this.http.post<ControleMadeira>(this.baseUrl + 'api/controleMadeira/obter', JSON.stringify(id), { headers: this.headers });

  }



}
