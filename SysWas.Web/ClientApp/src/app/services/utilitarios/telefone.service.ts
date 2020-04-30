import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Telefone } from '../../model/utilitarios/telefone';




@Injectable({

  providedIn: 'root'

})
export class TelefoneService implements OnInit {


  private baseUrl;
  public telefones: Telefone[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.telefones = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(telefone: Telefone): Observable<Telefone> {

    return this.http.post<Telefone>(this.baseUrl + 'api/telefone', JSON.stringify(telefone), { headers: this.headers });


  }

  public salvar(telefone: Telefone): Observable<Telefone> {

    return this.http.post<Telefone>(this.baseUrl + 'api/telefone/salvar', JSON.stringify(telefone), { headers: this.headers });


  }

  public deletar(telefone: Telefone): Observable<Telefone[]> {

    return this.http.post<Telefone[]>(this.baseUrl + 'api/telefone/deletar', JSON.stringify(telefone), { headers: this.headers });

  }

  public obterTodosTelefone(): Observable<Telefone[]> {

    return this.http.get<Telefone[]>(this.baseUrl + 'api/telefone');

  }

  public obterTelefone(produtoId: number): Observable<Telefone> {

    return this.http.get<Telefone>(this.baseUrl + 'api/telefone/obter');

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append('arquivoEnviado', arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this.baseUrl + 'api/telefone/enviarArquivo', formData);

  }


}
