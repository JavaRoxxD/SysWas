import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FormaPagamento } from '../../model/utilitarios/formaPagamento';




@Injectable({

  providedIn: 'root'

})
export class FormaPagamentoService implements OnInit {


  private baseUrl;
  public formaPagamentos: FormaPagamento[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.formaPagamentos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(formaPagamento: FormaPagamento): Observable<FormaPagamento> {

    return this.http.post<FormaPagamento>(this.baseUrl + 'api/formaPagamento', JSON.stringify(formaPagamento), { headers: this.headers });


  }

  public salvar(formaPagamento: FormaPagamento): Observable<FormaPagamento> {

    return this.http.post<FormaPagamento>(this.baseUrl + 'api/formaPagamento/salvar', JSON.stringify(formaPagamento), { headers: this.headers });


  }

  public deletar(formaPagamento: FormaPagamento): Observable<FormaPagamento[]> {

    return this.http.post<FormaPagamento[]>(this.baseUrl + 'api/formaPagamento/deletar', JSON.stringify(formaPagamento), { headers: this.headers });

  }

  public obterTodosFormaPagamento(): Observable<FormaPagamento[]> {

    return this.http.get<FormaPagamento[]>(this.baseUrl + 'api/formaPagamento');

  }

  public obterFormaPagamento(produtoId: number): Observable<FormaPagamento> {

    return this.http.get<FormaPagamento>(this.baseUrl + 'api/formaPagamento/obter');

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append('arquivoEnviado', arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this.baseUrl + 'api/formaPagamento/enviarArquivo', formData);

  }


}
