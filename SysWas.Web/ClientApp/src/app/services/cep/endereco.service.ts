import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Endereco } from '../../model/cep/endereco';
import { catchError } from 'rxjs/operators';





@Injectable({

  providedIn: 'root'

})
export class EnderecoService implements OnInit {


  private baseUrl;
  public enderecos: Endereco[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.enderecos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(endereco: Endereco): Observable<Endereco> {


    return this.http.post<Endereco>(this.baseUrl + 'api/endereco', JSON.stringify(endereco), { headers: this.headers });



  }

  public salvar(endereco: Endereco): Observable<Endereco> {

    return this.http.post<Endereco>(this.baseUrl + 'api/endereco/salvar', JSON.stringify(endereco), { headers: this.headers });


  }

  public deletar(endereco: Endereco): Observable<Endereco[]> {

    return this.http.post<Endereco[]>(this.baseUrl + 'api/endereco/deletar', JSON.stringify(endereco), { headers: this.headers });

  }

  public obterTodosEndereco(): Observable<Endereco[]> {

    return this.http.get<Endereco[]>(this.baseUrl + 'api/endereco');

  }

  public obterEndereco(cep: string): Observable<Endereco> {

    return this.http.get<Endereco>('https://viacep.com.br/ws/' + cep + '/json/', { headers: this.headers });

  }

  public obterEnderecoLogradouro(logradouro: string, localidade: string, uf: string): Observable<Endereco[]> {

    return this.http.get<Endereco[]>('https://viacep.com.br/ws/' + uf + '/' + localidade + '/' + logradouro + '/json/', { headers: this.headers });

  }


  public handleError(error: HttpErrorResponse) {

    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    
    return Observable.throw(error.message || "Server Error");

  }




}
