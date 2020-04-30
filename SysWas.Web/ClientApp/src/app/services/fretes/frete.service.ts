import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Frete } from '../../model/fretes/frete';





@Injectable({

  providedIn: 'root'

})
export class FreteService implements OnInit {


  private baseUrl;
  public fretes: Frete[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.fretes = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(frete: Frete): Observable<Frete> {

    return this.http.post<Frete>(this.baseUrl + 'api/frete', JSON.stringify(frete), { headers: this.headers });


  }

  public salvar(frete: Frete): Observable<Frete> {

    return this.http.post<Frete>(this.baseUrl + 'api/frete/salvar', JSON.stringify(frete), { headers: this.headers });


  }

  public deletar(frete: Frete): Observable<Frete[]> {

    return this.http.post<Frete[]>(this.baseUrl + 'api/frete/deletar', JSON.stringify(frete), { headers: this.headers });

  }

  public obterTodosFrete(): Observable<Frete[]> {

    return this.http.get<Frete[]>(this.baseUrl + 'api/frete');

  }

  public obterFrete(produtoId: number): Observable<Frete> {

    return this.http.get<Frete>(this.baseUrl + 'api/frete/obter');

  }



}
