import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Banco } from '../../model/utilitarios/banco';




@Injectable({

  providedIn: 'root'

})
export class BancoService implements OnInit {


  private baseUrl;
  public bancos: Banco[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.bancos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(banco: Banco): Observable<Banco> {

    return this.http.post<Banco>(this.baseUrl + 'api/banco', JSON.stringify(banco), { headers: this.headers });


  }

  public salvar(banco: Banco): Observable<Banco> {

    return this.http.post<Banco>(this.baseUrl + 'api/banco/salvar', JSON.stringify(banco), { headers: this.headers });


  }

  public deletar(banco: Banco): Observable<Banco[]> {

    return this.http.post<Banco[]>(this.baseUrl + 'api/banco/deletar', JSON.stringify(banco), { headers: this.headers });

  }

  public obterTodosBanco(): Observable<Banco[]> {

    return this.http.get<Banco[]>(this.baseUrl + 'api/banco');

  }

  public obterBanco(produtoId: number): Observable<Banco> {

    return this.http.get<Banco>(this.baseUrl + 'api/banco/obter');

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append('arquivoEnviado', arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this.baseUrl + 'api/banco/enviarArquivo', formData);

  }


}
