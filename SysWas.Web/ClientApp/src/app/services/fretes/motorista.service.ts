import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Motorista } from '../../model/fretes/motorista';





@Injectable({

  providedIn: 'root'

})
export class MotoristaService implements OnInit {


  private baseUrl;
  public motoristas: Motorista[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.motoristas = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(motorista: Motorista): Observable<Motorista> {

    return this.http.post<Motorista>(this.baseUrl + 'api/motorista', JSON.stringify(motorista), { headers: this.headers });


  }

  public salvar(motorista: Motorista): Observable<Motorista> {

    return this.http.post<Motorista>(this.baseUrl + 'api/motorista/salvar', JSON.stringify(motorista), { headers: this.headers });


  }

  public deletar(motorista: Motorista): Observable<Motorista[]> {

    return this.http.post<Motorista[]>(this.baseUrl + 'api/motorista/deletar', JSON.stringify(motorista), { headers: this.headers });

  }

  public obterTodosMotorista(): Observable<Motorista[]> {

    return this.http.get<Motorista[]>(this.baseUrl + 'api/motorista');

  }

  public obterMotorista(produtoId: number): Observable<Motorista> {

    return this.http.get<Motorista>(this.baseUrl + 'api/motorista/obter');

  }



}
