import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { BuscaService } from '../busca-cliente/busca.service';

@Component({
  selector: 'app-oferta-cliente',
  templateUrl: './oferta-cliente.component.html',
  styleUrls: ['./oferta-cliente.component.css']
})
export class OfertaClienteComponent implements OnInit {

  form: any;
  cpf: string = '';
  cliente: any;

  constructor(private formBuilder: FormBuilder,
              private buscaService: BuscaService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.cpf = location.href.split('/')[5]
    this.buscaService.buscar('', this.cpf)
        .subscribe(
          response => {
              this.cliente = response;
              this.criarForma();
          },
          err => {
              this.cliente = err;
          }
      );
  }

  criarForma(): void{
    this.form = this.formBuilder.group({
      nome: this.cliente[0].nome,
      cpf: this.cliente[0].cpf,
      telefone: this.cliente[0].telefone,
      credito: this.cliente[0].credito,
      status: this.cliente[0].status,
      cep: [''],
      rua: [''],
      numero: [''],
      complemento: [''],
      bairro: [''],
      cidade: [''],
      estado: [''],
    });
  }

  cadastrarOferta(): void{

  }

}
