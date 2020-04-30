import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SecEdit } from '../../model/utilitarios/secEdit';




@Injectable({

  providedIn: 'root'

})
export class SecEditService implements OnInit {


  private baseUrl;
  public secEdits: SecEdit[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.secEdits = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(secEdit: SecEdit): Observable<SecEdit> {

    return this.http.post<SecEdit>(this.baseUrl + 'api/secEdit', JSON.stringify(secEdit), { headers: this.headers });


  }

  public salvar(secEdit: SecEdit): Observable<SecEdit> {

    return this.http.post<SecEdit>(this.baseUrl + 'api/secEdit/salvar', JSON.stringify(secEdit), { headers: this.headers });


  }

  public deletar(secEdit: SecEdit): Observable<SecEdit[]> {

    return this.http.post<SecEdit[]>(this.baseUrl + 'api/secEdit/deletar', JSON.stringify(secEdit), { headers: this.headers });

  }

  public obterTodosSecEdit(): Observable<SecEdit[]> {

    return this.http.get<SecEdit[]>(this.baseUrl + 'api/secEdit');

  }

  public obterSecEdit(produtoId: number): Observable<SecEdit> {

    return this.http.get<SecEdit>(this.baseUrl + 'api/secEdit/obter');

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append('arquivoEnviado', arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this.baseUrl + 'api/secEdit/enviarArquivo', formData);

  }


}
