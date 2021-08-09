import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BuscaService {

  constructor(private http: HttpClient) { }

  nome: string = '';
  cpf: number = 0;

  httpOptions = {
    headers: new HttpHeaders(
        {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${sessionStorage.getItem('token')}`
        }
      )
  }

  buscar(nome: string, cpf: number): Observable<object>{
    if(nome.length > 0){
      return this.http.get('https://localhost:5001/api/clientes/buscar-por-nome', this.httpOptions);
    }else{
      return this.http.get('https://localhost:5001/api/clientes/buscar-por-cpf', this.httpOptions);
    }
  }
}
