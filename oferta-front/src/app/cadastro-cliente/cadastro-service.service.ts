import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {

  constructor(private http: HttpClient) { }

  cliente: any;
  nome: string = '';
  telefone: string = '';
  cpf: number = 0;
  credito: number = 0;

  httpOptions = {
    headers: new HttpHeaders(
        {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${sessionStorage.getItem('token')}`
        }
      )
  }

  cadastrar(nome: string, telefone: string, cpf: number, credito: number): Observable<object>{
    this.cliente = {
      nome,
      telefone,
      cpf,
      credito
    };

    return this.http.post('https://localhost:5001/api/clientes/inserir', this.cliente, this.httpOptions);
  }
}
