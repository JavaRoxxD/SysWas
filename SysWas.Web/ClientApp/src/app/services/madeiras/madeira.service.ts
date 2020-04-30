import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Madeira } from '../../model/madeiras/madeira';



@Injectable({

  providedIn: 'root'

})
export class MadeiraService implements OnInit {


  private baseUrl;
  public madeiras: Madeira[];

 constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
 }

  ngOnInit(): void {
    this.madeiras = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(madeira: Madeira): Observable<Madeira> {

    return this.http.post<Madeira>(this.baseUrl + 'api/madeira', JSON.stringify(madeira), { headers: this.headers });


  }

  public salvar(madeira: Madeira): Observable<Madeira> {

    return this.http.post<Madeira>(this.baseUrl + 'api/madeira/salvar', JSON.stringify(madeira), { headers: this.headers });


  }

  public deletar(madeira: Madeira): Observable<Madeira[]> {

    return this.http.post<Madeira[]>(this.baseUrl + 'api/madeira/deletar', JSON.stringify(madeira), { headers: this.headers });

  }

  public obterTodosMadeira(): Observable<Madeira[]> {

    return this.http.get<Madeira[]>(this.baseUrl + 'api/madeira');

  }

  public obterMadeira(produtoId: number): Observable<Madeira> {

    return this.http.get<Madeira>(this.baseUrl + 'api/madeira/obter');

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append('arquivoEnviado', arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this.baseUrl + 'api/madeira/enviarArquivo', formData);

  }


}
