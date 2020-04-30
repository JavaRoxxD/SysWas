import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoCusto } from '../../model/financeiro/tipoCusto';





@Injectable({

  providedIn: 'root'

})
export class TipoCustoService implements OnInit {


  private baseUrl;
  public tipoCustos: TipoCusto[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.tipoCustos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(tipoCusto: TipoCusto): Observable<TipoCusto> {

    return this.http.post<TipoCusto>(this.baseUrl + 'api/tipoCusto', JSON.stringify(tipoCusto), { headers: this.headers });


  }

  public salvar(tipoCusto: TipoCusto): Observable<TipoCusto> {

    return this.http.post<TipoCusto>(this.baseUrl + 'api/tipoCusto/salvar', JSON.stringify(tipoCusto), { headers: this.headers });


  }

  public deletar(tipoCusto: TipoCusto): Observable<TipoCusto[]> {

    return this.http.post<TipoCusto[]>(this.baseUrl + 'api/tipoCusto/deletar', JSON.stringify(tipoCusto), { headers: this.headers });

  }

  public obterTodosTipoCusto(): Observable<TipoCusto[]> {

    return this.http.get<TipoCusto[]>(this.baseUrl + 'api/tipoCusto');

  }

  public obterTipoCusto(produtoId: number): Observable<TipoCusto> {

    return this.http.get<TipoCusto>(this.baseUrl + 'api/tipoCusto/obter');

  }



}
