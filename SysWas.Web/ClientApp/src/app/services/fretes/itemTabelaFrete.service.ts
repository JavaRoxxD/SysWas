import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ItemTabelaFrete } from '../../model/fretes/itemTabelaFrete';





@Injectable({

  providedIn: 'root'

})
export class ItemTabelaFreteService implements OnInit {


  private baseUrl;
  public itemTabelaFretes: ItemTabelaFrete[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.itemTabelaFretes = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(itemTabelaFrete: ItemTabelaFrete): Observable<ItemTabelaFrete> {

    return this.http.post<ItemTabelaFrete>(this.baseUrl + 'api/itemTabelaFrete', JSON.stringify(itemTabelaFrete), { headers: this.headers });


  }

  public salvar(itemTabelaFrete: ItemTabelaFrete): Observable<ItemTabelaFrete> {

    return this.http.post<ItemTabelaFrete>(this.baseUrl + 'api/itemTabelaFrete/salvar', JSON.stringify(itemTabelaFrete), { headers: this.headers });


  }

  public deletar(itemTabelaFrete: ItemTabelaFrete): Observable<ItemTabelaFrete[]> {

    return this.http.post<ItemTabelaFrete[]>(this.baseUrl + 'api/itemTabelaFrete/deletar', JSON.stringify(itemTabelaFrete), { headers: this.headers });

  }

  public obterTodosItemTabelaFrete(): Observable<ItemTabelaFrete[]> {

    return this.http.get<ItemTabelaFrete[]>(this.baseUrl + 'api/itemTabelaFrete');

  }

  public obterItemTabelaFrete(produtoId: number): Observable<ItemTabelaFrete> {

    return this.http.get<ItemTabelaFrete>(this.baseUrl + 'api/itemTabelaFrete/obter');

  }



}
