import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { CadastroService } from './cadastro-service.service';

@Component({
  selector: 'app-cadastro-cliente',
  templateUrl: './cadastro-cliente.component.html',
  styleUrls: ['./cadastro-cliente.component.css']
})
export class CadastroClienteComponent {

  form: any;
  nome: string = '';
  telefone: string = '';
  cpf: number = 0;
  credito: number = 0;
  response: any;
  mensagem: string = '';

  constructor(private formBuilder: FormBuilder,
              private cadastroService: CadastroService,
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

  cadastrarCliente(): void{
    this.nome = this.form.get('nome').value;
    this.cpf = this.form.get('cpf').value;
    this.telefone = this.form.get('telefone').value;
    this.credito = this.form.get('credito').value;

    this.cadastroService.cadastrar(this.nome, this.telefone, this.cpf, this.credito)
        .subscribe(
            response => {
                this.response = response;
                sessionStorage.setItem('token', this.response.token);
                this.router.navigate(['/']);
            },
            err => {
                this.response = err;
                this.mensagem = this.response.error;
            }
        );
  }

}
