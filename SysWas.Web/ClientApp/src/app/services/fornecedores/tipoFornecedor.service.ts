import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoFornecedor } from '../../model/Fornecedores/tipoFornecedor';





@Injectable({

  providedIn: 'root'

})
export class TipoFornecedorService implements OnInit {


  private baseUrl;
  public tipoFornecedors: TipoFornecedor[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.tipoFornecedors = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(tipoFornecedor: TipoFornecedor): Observable<TipoFornecedor> {

    return this.http.post<TipoFornecedor>(this.baseUrl + 'api/tipoFornecedor', JSON.stringify(tipoFornecedor), { headers: this.headers });


  }

  public salvar(tipoFornecedor: TipoFornecedor): Observable<TipoFornecedor> {

    return this.http.post<TipoFornecedor>(this.baseUrl + 'api/tipoFornecedor/salvar', JSON.stringify(tipoFornecedor), { headers: this.headers });


  }

  public deletar(tipoFornecedor: TipoFornecedor): Observable<TipoFornecedor[]> {

    return this.http.post<TipoFornecedor[]>(this.baseUrl + 'api/tipoFornecedor/deletar', JSON.stringify(tipoFornecedor), { headers: this.headers });

  }

  public obterTodosTipoFornecedor(): Observable<TipoFornecedor[]> {

    return this.http.get<TipoFornecedor[]>(this.baseUrl + 'api/tipoFornecedor');

  }

  public obterTipoFornecedor(produtoId: number): Observable<TipoFornecedor> {

    return this.http.get<TipoFornecedor>(this.baseUrl + 'api/tipoFornecedor/obter');

  }



}
