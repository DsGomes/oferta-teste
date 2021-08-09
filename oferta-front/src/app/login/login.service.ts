import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  usuario: any;

  authenticate(nome: string, email: string): Observable<object>{
    this.usuario = {
      nome,
      email,
      role: 'Sistema'
    };

    return this.http.post('https://localhost:5001/api/auth/autenticar', this.usuario);
  }
}
