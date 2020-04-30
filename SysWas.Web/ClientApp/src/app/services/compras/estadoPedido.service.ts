import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EstadoPedido } from '../../model/compras/estadoPedido';





@Injectable({

  providedIn: 'root'

})
export class EstadoPedidoService implements OnInit {


  private baseUrl;
  public estadoPedidos: EstadoPedido[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.estadoPedidos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(estadoPedido: EstadoPedido): Observable<EstadoPedido> {

    return this.http.post<EstadoPedido>(this.baseUrl + 'api/estadoPedido', JSON.stringify(estadoPedido), { headers: this.headers });


  }

  public salvar(estadoPedido: EstadoPedido): Observable<EstadoPedido> {

    return this.http.post<EstadoPedido>(this.baseUrl + 'api/estadoPedido/salvar', JSON.stringify(estadoPedido), { headers: this.headers });


  }

  public deletar(estadoPedido: EstadoPedido): Observable<EstadoPedido[]> {

    return this.http.post<EstadoPedido[]>(this.baseUrl + 'api/estadoPedido/deletar', JSON.stringify(estadoPedido), { headers: this.headers });

  }

  public obterTodosEstadoPedido(): Observable<EstadoPedido[]> {

    return this.http.get<EstadoPedido[]>(this.baseUrl + 'api/estadoPedido');

  }

  public obterEstadoPedido(produtoId: number): Observable<EstadoPedido> {

    return this.http.get<EstadoPedido>(this.baseUrl + 'api/estadoPedido/obter');

  }



}
