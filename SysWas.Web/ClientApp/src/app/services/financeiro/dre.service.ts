import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dre } from '../../model/financeiro/dre';





@Injectable({

  providedIn: 'root'

})
export class DreService implements OnInit {


  private baseUrl;
  public dres: Dre[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.dres = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(dre: Dre): Observable<Dre> {

    return this.http.post<Dre>(this.baseUrl + 'api/dre', JSON.stringify(dre), { headers: this.headers });


  }

  public salvar(dre: Dre): Observable<Dre> {

    return this.http.post<Dre>(this.baseUrl + 'api/dre/salvar', JSON.stringify(dre), { headers: this.headers });


  }

  public deletar(dre: Dre): Observable<Dre[]> {

    return this.http.post<Dre[]>(this.baseUrl + 'api/dre/deletar', JSON.stringify(dre), { headers: this.headers });

  }

  public obterTodosDre(): Observable<Dre[]> {

    return this.http.get<Dre[]>(this.baseUrl + 'api/dre');

  }

  public obterDre(produtoId: number): Observable<Dre> {

    return this.http.get<Dre>(this.baseUrl + 'api/dre/obter');

  }



}
