import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OfertaService {

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders(
        {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${sessionStorage.getItem('token')}`
        }
      )
  }

  buscarProdutos(): Observable<object>{
      return this.http.get('https://localhost:5001/api/produtos/buscar-todos', this.httpOptions);
  }

  inserirVendas(id: number, produtos: any): Observable<object>{
    return this.http.post(`https://localhost:5001/api/vendas/cadastrar-venda?id_cliente=${id}`, { produtos: produtos }, this.httpOptions);
  }

  inserirEndereco(endereco: any): Observable<object>{
    return this.http.post('https://localhost:5001/api/enderecos/cadastrar-endereco', { endereco: endereco }, this.httpOptions);
  }

  buscarStatus(): Observable<object>{
    return this.http.get('https://localhost:5001/api/clientes/buscar-status', this.httpOptions);
  }
}
