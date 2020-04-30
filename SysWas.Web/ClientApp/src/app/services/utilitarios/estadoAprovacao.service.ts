import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EstadoAprovacao } from '../../model/utilitarios/estadoAprovacao';




@Injectable({

  providedIn: 'root'

})
export class EstadoAprovacaoService implements OnInit {


  private baseUrl;
  public estadoAprovacaos: EstadoAprovacao[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.estadoAprovacaos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(estadoAprovacao: EstadoAprovacao): Observable<EstadoAprovacao> {

    return this.http.post<EstadoAprovacao>(this.baseUrl + 'api/estadoAprovacao', JSON.stringify(estadoAprovacao), { headers: this.headers });


  }

  public salvar(estadoAprovacao: EstadoAprovacao): Observable<EstadoAprovacao> {

    return this.http.post<EstadoAprovacao>(this.baseUrl + 'api/estadoAprovacao/salvar', JSON.stringify(estadoAprovacao), { headers: this.headers });


  }

  public deletar(estadoAprovacao: EstadoAprovacao): Observable<EstadoAprovacao[]> {

    return this.http.post<EstadoAprovacao[]>(this.baseUrl + 'api/estadoAprovacao/deletar', JSON.stringify(estadoAprovacao), { headers: this.headers });

  }

  public obterTodosEstadoAprovacao(): Observable<EstadoAprovacao[]> {

    return this.http.get<EstadoAprovacao[]>(this.baseUrl + 'api/estadoAprovacao');

  }

  public obterEstadoAprovacao(produtoId: number): Observable<EstadoAprovacao> {

    return this.http.get<EstadoAprovacao>(this.baseUrl + 'api/estadoAprovacao/obter');

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append('arquivoEnviado', arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this.baseUrl + 'api/estadoAprovacao/enviarArquivo', formData);

  }


}
