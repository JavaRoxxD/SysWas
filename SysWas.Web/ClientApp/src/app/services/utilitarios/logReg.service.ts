import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LogReg } from '../../model/utilitarios/logReg';




@Injectable({

  providedIn: 'root'

})
export class LogRegService implements OnInit {


  private baseUrl;
  public logRegs: LogReg[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.logRegs = [];
  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');

  }



  public cadastrar(logReg: LogReg): Observable<LogReg> {

    return this.http.post<LogReg>(this.baseUrl + 'api/logReg', JSON.stringify(logReg), { headers: this.headers });


  }

  public salvar(logReg: LogReg): Observable<LogReg> {

    return this.http.post<LogReg>(this.baseUrl + 'api/logReg/salvar', JSON.stringify(logReg), { headers: this.headers });


  }

  public deletar(logReg: LogReg): Observable<LogReg[]> {

    return this.http.post<LogReg[]>(this.baseUrl + 'api/logReg/deletar', JSON.stringify(logReg), { headers: this.headers });

  }

  public obterTodosLogReg(): Observable<LogReg[]> {

    return this.http.get<LogReg[]>(this.baseUrl + 'api/logReg');

  }

  public obterLogReg(produtoId: number): Observable<LogReg> {

    return this.http.get<LogReg>(this.baseUrl + 'api/logReg/obter');

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append('arquivoEnviado', arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this.baseUrl + 'api/logReg/enviarArquivo', formData);

  }


}
