import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NotaFiscal } from '../../model/utilitarios/notaFiscal';




@Injectable({

  providedIn: 'root'

})
export class NotaFiscalService implements OnInit {


  private baseUrl;
  public notaFiscals: NotaFiscal[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.notaFiscals = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(notaFiscal: NotaFiscal): Observable<NotaFiscal> {

    return this.http.post<NotaFiscal>(this.baseUrl + 'api/notaFiscal', JSON.stringify(notaFiscal), { headers: this.headers });


  }

  public salvar(notaFiscal: NotaFiscal): Observable<NotaFiscal> {

    return this.http.post<NotaFiscal>(this.baseUrl + 'api/notaFiscal/salvar', JSON.stringify(notaFiscal), { headers: this.headers });


  }

  public deletar(notaFiscal: NotaFiscal): Observable<NotaFiscal[]> {

    return this.http.post<NotaFiscal[]>(this.baseUrl + 'api/notaFiscal/deletar', JSON.stringify(notaFiscal), { headers: this.headers });

  }

  public obterTodosNotaFiscal(): Observable<NotaFiscal[]> {

    return this.http.get<NotaFiscal[]>(this.baseUrl + 'api/notaFiscal');

  }

  public obterNotaFiscal(produtoId: number): Observable<NotaFiscal> {

    return this.http.get<NotaFiscal>(this.baseUrl + 'api/notaFiscal/obter');

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append('arquivoEnviado', arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this.baseUrl + 'api/notaFiscal/enviarArquivo', formData);

  }


}
