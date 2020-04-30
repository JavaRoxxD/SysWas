import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListaContato } from '../../model/Fornecedores/listaContato';





@Injectable({

  providedIn: 'root'

})
export class ListaContatoService implements OnInit {


  private baseUrl;
  public listaContatos: ListaContato[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.listaContatos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(listaContato: ListaContato): Observable<ListaContato> {

    return this.http.post<ListaContato>(this.baseUrl + 'api/listaContato', JSON.stringify(listaContato), { headers: this.headers });


  }

  public salvar(listaContato: ListaContato): Observable<ListaContato> {

    return this.http.post<ListaContato>(this.baseUrl + 'api/listaContato/salvar', JSON.stringify(listaContato), { headers: this.headers });


  }

  public deletar(listaContato: ListaContato): Observable<ListaContato[]> {

    return this.http.post<ListaContato[]>(this.baseUrl + 'api/listaContato/deletar', JSON.stringify(listaContato), { headers: this.headers });

  }

  public obterTodosListaContato(): Observable<ListaContato[]> {

    return this.http.get<ListaContato[]>(this.baseUrl + 'api/listaContato');

  }

  public obterListaContato(produtoId: number): Observable<ListaContato> {

    return this.http.get<ListaContato>(this.baseUrl + 'api/listaContato/obter');

  }



}
