import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pedido } from '../../model/compras/pedido';





@Injectable({

  providedIn: 'root'

})
export class PedidoService implements OnInit {


  private baseUrl;
  public pedidos: Pedido[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.pedidos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(pedido: Pedido): Observable<Pedido> {

    return this.http.post<Pedido>(this.baseUrl + 'api/pedido', JSON.stringify(pedido), { headers: this.headers });


  }

  public salvar(pedido: Pedido): Observable<Pedido> {

    return this.http.post<Pedido>(this.baseUrl + 'api/pedido/salvar', JSON.stringify(pedido), { headers: this.headers });


  }

  public deletar(pedido: Pedido): Observable<Pedido[]> {

    return this.http.post<Pedido[]>(this.baseUrl + 'api/pedido/deletar', JSON.stringify(pedido), { headers: this.headers });

  }

  public obterTodosPedido(): Observable<Pedido[]> {

    return this.http.get<Pedido[]>(this.baseUrl + 'api/pedido');

  }

  public obterPedido(produtoId: number): Observable<Pedido> {

    return this.http.get<Pedido>(this.baseUrl + 'api/pedido/obter');

  }



}
