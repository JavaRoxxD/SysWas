import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Fornecedor } from '../../model/Fornecedores/fornecedor';





@Injectable({

  providedIn: 'root'

})
export class FornecedorService implements OnInit {


  private baseUrl;
  public fornecedors: Fornecedor[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.fornecedors = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(fornecedor: Fornecedor): Observable<Fornecedor> {

    return this.http.post<Fornecedor>(this.baseUrl + 'api/fornecedor', JSON.stringify(fornecedor), { headers: this.headers });


  }

  public salvar(fornecedor: Fornecedor): Observable<Fornecedor> {

    return this.http.post<Fornecedor>(this.baseUrl + 'api/fornecedor/salvar', JSON.stringify(fornecedor), { headers: this.headers });


  }

  public deletar(fornecedor: Fornecedor): Observable<Fornecedor[]> {

    return this.http.post<Fornecedor[]>(this.baseUrl + 'api/fornecedor/deletar', JSON.stringify(fornecedor), { headers: this.headers });

  }

  public obterTodosFornecedor(): Observable<Fornecedor[]> {

    return this.http.get<Fornecedor[]>(this.baseUrl + 'api/fornecedor');

  }

  public obterFornecedor(produtoId: number): Observable<Fornecedor> {

    return this.http.get<Fornecedor>(this.baseUrl + 'api/fornecedor/obter');

  }



}
