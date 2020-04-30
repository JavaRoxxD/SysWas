import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Email } from '../../model/utilitarios/email';




@Injectable({

  providedIn: 'root'

})
export class EmailService implements OnInit {


  private baseUrl;
  public emails: Email[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.emails = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(email: Email): Observable<Email> {

    return this.http.post<Email>(this.baseUrl + 'api/email', JSON.stringify(email), { headers: this.headers });


  }

  public salvar(email: Email): Observable<Email> {

    return this.http.post<Email>(this.baseUrl + 'api/email/salvar', JSON.stringify(email), { headers: this.headers });


  }

  public deletar(email: Email): Observable<Email[]> {

    return this.http.post<Email[]>(this.baseUrl + 'api/email/deletar', JSON.stringify(email), { headers: this.headers });

  }

  public obterTodosEmail(): Observable<Email[]> {

    return this.http.get<Email[]>(this.baseUrl + 'api/email');

  }

  public obterEmail(produtoId: number): Observable<Email> {

    return this.http.get<Email>(this.baseUrl + 'api/email/obter');

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append('arquivoEnviado', arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this.baseUrl + 'api/email/enviarArquivo', formData);

  }


}
