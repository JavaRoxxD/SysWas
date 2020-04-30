import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sexo } from '../../model/utilitarios/sexo';




@Injectable({

  providedIn: 'root'

})
export class SexoService implements OnInit {


  private baseUrl;
  public sexos: Sexo[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.sexos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(sexo: Sexo): Observable<Sexo> {

    return this.http.post<Sexo>(this.baseUrl + 'api/sexo', JSON.stringify(sexo), { headers: this.headers });


  }

  public salvar(sexo: Sexo): Observable<Sexo> {

    return this.http.post<Sexo>(this.baseUrl + 'api/sexo/salvar', JSON.stringify(sexo), { headers: this.headers });


  }

  public deletar(sexo: Sexo): Observable<Sexo[]> {

    return this.http.post<Sexo[]>(this.baseUrl + 'api/sexo/deletar', JSON.stringify(sexo), { headers: this.headers });

  }

  public obterTodosSexo(): Observable<Sexo[]> {

    return this.http.get<Sexo[]>(this.baseUrl + 'api/sexo');

  }

  public obterSexo(produtoId: number): Observable<Sexo> {

    return this.http.get<Sexo>(this.baseUrl + 'api/sexo/obter');

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append('arquivoEnviado', arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this.baseUrl + 'api/sexo/enviarArquivo', formData);

  }


}

