import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Empresa } from '../../model/empresas/empresa';





@Injectable({

  providedIn: 'root'

})
export class EmpresaService implements OnInit {


  private baseUrl;
  public empresas: Empresa[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.empresas = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(empresa: Empresa): Observable<Empresa> {

    return this.http.post<Empresa>(this.baseUrl + 'api/empresa', JSON.stringify(empresa), { headers: this.headers });


  }

  public salvar(empresa: Empresa): Observable<Empresa> {

    return this.http.post<Empresa>(this.baseUrl + 'api/empresa/salvar', JSON.stringify(empresa), { headers: this.headers });


  }

  public deletar(empresa: Empresa): Observable<Empresa[]> {

    return this.http.post<Empresa[]>(this.baseUrl + 'api/empresa/deletar', JSON.stringify(empresa), { headers: this.headers });

  }

  public obterTodosEmpresa(): Observable<Empresa[]> {

    return this.http.get<Empresa[]>(this.baseUrl + 'api/empresa');

  }

  public obterEmpresa(produtoId: number): Observable<Empresa> {

    return this.http.get<Empresa>(this.baseUrl + 'api/empresa/obter');

  }



}
