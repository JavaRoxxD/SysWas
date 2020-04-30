import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Custo } from '../../model/financeiro/custo';




@Injectable({

  providedIn: 'root'

})
export class CustoService implements OnInit {


  private baseUrl;
  public custos: Custo[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.custos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(custo: Custo): Observable<Custo> {

    return this.http.post<Custo>(this.baseUrl + 'api/custo', JSON.stringify(custo), { headers: this.headers });


  }

  public salvar(custo: Custo): Observable<Custo> {

    return this.http.post<Custo>(this.baseUrl + 'api/custo/salvar', JSON.stringify(custo), { headers: this.headers });


  }

  public deletar(custo: Custo): Observable<Custo[]> {

    return this.http.post<Custo[]>(this.baseUrl + 'api/custo/deletar', JSON.stringify(custo), { headers: this.headers });

  }

  public obterTodosCusto(): Observable<Custo[]> {

    return this.http.get<Custo[]>(this.baseUrl + 'api/custo');

  }

  public obterCusto(produtoId: number): Observable<Custo> {

    return this.http.get<Custo>(this.baseUrl + 'api/custo/obter');

  }



}
