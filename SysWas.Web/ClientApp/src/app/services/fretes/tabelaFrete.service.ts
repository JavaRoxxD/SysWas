import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TabelaFrete } from '../../model/fretes/tabelaFrete';





@Injectable({

  providedIn: 'root'

})
export class TabelaFreteService implements OnInit {


  private baseUrl;
  public tabelaFretes: TabelaFrete[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.tabelaFretes = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(tabelaFrete: TabelaFrete): Observable<TabelaFrete> {

    return this.http.post<TabelaFrete>(this.baseUrl + 'api/tabelaFrete', JSON.stringify(tabelaFrete), { headers: this.headers });


  }

  public salvar(tabelaFrete: TabelaFrete): Observable<TabelaFrete> {

    return this.http.post<TabelaFrete>(this.baseUrl + 'api/tabelaFrete/salvar', JSON.stringify(tabelaFrete), { headers: this.headers });


  }

  public deletar(tabelaFrete: TabelaFrete): Observable<TabelaFrete[]> {

    return this.http.post<TabelaFrete[]>(this.baseUrl + 'api/tabelaFrete/deletar', JSON.stringify(tabelaFrete), { headers: this.headers });

  }

  public obterTodosTabelaFrete(): Observable<TabelaFrete[]> {

    return this.http.get<TabelaFrete[]>(this.baseUrl + 'api/tabelaFrete');

  }

  public obterTabelaFrete(produtoId: number): Observable<TabelaFrete> {

    return this.http.get<TabelaFrete>(this.baseUrl + 'api/tabelaFrete/obter');

  }



}
