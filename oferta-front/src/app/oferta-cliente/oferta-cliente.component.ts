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

  constructor(private formBuilder: FormBuilder,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.criarForma();
    this.cpf = location.href.split('/')[5]
  }

  criarForma(): void{
    this.form = this.formBuilder.group({
      nome: [''],
      cpf: [''],
      telefone: [''],
      credito: [''],
      status: ['']
    });
  }

  cadastrarOferta(): void{

  }

}
