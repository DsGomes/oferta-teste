import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { BuscaService } from './busca.service';

@Component({
  selector: 'app-busca-cliente',
  templateUrl: './busca-cliente.component.html',
  styleUrls: ['./busca-cliente.component.css']
})
export class BuscaClienteComponent {

  form: any;
  nome: string = '';
  cpf: number = 0;
  response: any;

  constructor(private formBuilder: FormBuilder,
              private buscaService: BuscaService,
              private router: Router) 
    { 
      this.criarForma();
    }

    criarForma(): void{
      this.form = this.formBuilder.group({
        nome: [''],
        cpf: [''],
        telefone: [''],
        credito: ['']
      });
    }

    buscarCliente(): void{
      this.nome = this.form.get('nome').value;
      this.cpf = this.form.get('cpf').value;
  
      this.buscaService.buscar(this.nome, this.cpf)
          .subscribe(
              response => {
                  this.response = response;
                  sessionStorage.setItem('token', this.response.token);
                  this.router.navigate(['/']);
              },
              err => {
                  this.response = err;
              }
          );
    }
}
