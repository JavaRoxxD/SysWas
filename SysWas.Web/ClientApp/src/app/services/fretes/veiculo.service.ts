import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Veiculo } from '../../model/fretes/veiculo';





@Injectable({

  providedIn: 'root'

})
export class VeiculoService implements OnInit {


  private baseUrl;
  public veiculos: Veiculo[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.veiculos = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(veiculo: Veiculo): Observable<Veiculo> {

    return this.http.post<Veiculo>(this.baseUrl + 'api/veiculo', JSON.stringify(veiculo), { headers: this.headers });


  }

  public salvar(veiculo: Veiculo): Observable<Veiculo> {

    return this.http.post<Veiculo>(this.baseUrl + 'api/veiculo/salvar', JSON.stringify(veiculo), { headers: this.headers });


  }

  public deletar(veiculo: Veiculo): Observable<Veiculo[]> {

    return this.http.post<Veiculo[]>(this.baseUrl + 'api/veiculo/deletar', JSON.stringify(veiculo), { headers: this.headers });

  }

  public obterTodosVeiculo(): Observable<Veiculo[]> {

    return this.http.get<Veiculo[]>(this.baseUrl + 'api/veiculo');

  }

  public obterVeiculo(produtoId: number): Observable<Veiculo> {

    return this.http.get<Veiculo>(this.baseUrl + 'api/veiculo/obter');

  }



}
