import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Transportadora } from '../../model/fretes/transportadora';





@Injectable({

  providedIn: 'root'

})
export class TransportadoraService implements OnInit {


  private baseUrl;
  public transportadoras: Transportadora[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.transportadoras = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(transportadora: Transportadora): Observable<Transportadora> {

    return this.http.post<Transportadora>(this.baseUrl + 'api/transportadora', JSON.stringify(transportadora), { headers: this.headers });


  }

  public salvar(transportadora: Transportadora): Observable<Transportadora> {

    return this.http.post<Transportadora>(this.baseUrl + 'api/transportadora/salvar', JSON.stringify(transportadora), { headers: this.headers });


  }

  public deletar(transportadora: Transportadora): Observable<Transportadora[]> {

    return this.http.post<Transportadora[]>(this.baseUrl + 'api/transportadora/deletar', JSON.stringify(transportadora), { headers: this.headers });

  }

  public obterTodosTransportadora(): Observable<Transportadora[]> {

    return this.http.get<Transportadora[]>(this.baseUrl + 'api/transportadora');

  }

  public obterTransportadora(produtoId: number): Observable<Transportadora> {

    return this.http.get<Transportadora>(this.baseUrl + 'api/transportadora/obter');

  }



}
