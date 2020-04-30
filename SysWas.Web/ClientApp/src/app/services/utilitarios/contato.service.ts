import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contato } from '../../model/utilitarios/contato';




@Injectable({

  providedIn: 'root'

})
export class ContatoService implements OnInit {


  private baseUrl;
  public contatos: Contato[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.contatos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(contato: Contato): Observable<Contato> {

    return this.http.post<Contato>(this.baseUrl + 'api/contato', JSON.stringify(contato), { headers: this.headers });


  }

  public salvar(contato: Contato): Observable<Contato> {

    return this.http.post<Contato>(this.baseUrl + 'api/contato/salvar', JSON.stringify(contato), { headers: this.headers });


  }

  public deletar(contato: Contato): Observable<Contato[]> {

    return this.http.post<Contato[]>(this.baseUrl + 'api/contato/deletar', JSON.stringify(contato), { headers: this.headers });

  }

  public obterTodosContato(): Observable<Contato[]> {

    return this.http.get<Contato[]>(this.baseUrl + 'api/contato');

  }

  public obterContato(produtoId: number): Observable<Contato> {

    return this.http.get<Contato>(this.baseUrl + 'api/contato/obter');

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append('arquivoEnviado', arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this.baseUrl + 'api/contato/enviarArquivo', formData);

  }


}
