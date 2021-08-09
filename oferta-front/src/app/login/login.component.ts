import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { LoginService } from './login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: any;
  nome: string = '';
  email: string = '';
  mensagem: string = '';
  response: any;

  constructor(private formBuilder: FormBuilder,
              private loginService: LoginService,
              private router: Router) {
    this.criarForma();
   }

  ngOnInit(): void {
    sessionStorage.clear();
  }

   criarForma(): void{
    this.form = this.formBuilder.group({
      nome: [''],
      email: ['']
    });
   }

   login(): void{

      this.nome = this.form.get('nome').value;
      this.email = this.form.get('email').value;

      this.loginService.authenticate(this.nome, this.email)
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
