import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { BuscaService } from '../busca-cliente/busca.service';
import { OfertaService } from './oferta.service';

@Component({
  selector: 'app-oferta-cliente',
  templateUrl: './oferta-cliente.component.html',
  styleUrls: ['./oferta-cliente.component.css']
})
export class OfertaClienteComponent implements OnInit {

  form: any;
  cpf: string = '';
  cliente: any;
  produtos: any;
  status: any;
  produtoInserido: number[] = [];
  statusSelecionado: number = 0;
  endereco: any;

  constructor(private formBuilder: FormBuilder,
              private buscaService: BuscaService,
              private ofertaService: OfertaService,
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

    this.ofertaService.buscarProdutos()
          .subscribe(
            response => {
              this.produtos = response;
            },
            err => {
              this.produtos = err;
            }
          );

    this.ofertaService.buscarStatus()
          .subscribe(
            response => {
                this.status = response;
            },
            err => {
                this.status = err;
            })
  }

  criarForma(): void{
    this.form = this.formBuilder.group({
      cod_cliente: this.cliente[0].cod_cliente,
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
      estado: ['']
    });
  }

  inserirProduto(id: number): void{
    this.produtoInserido.push(id);
  }

  inserirStatus(id: number): void{
    this.statusSelecionado = id;
  }

  cadastrarOferta(): void{
    if(this.form.value.cep.length > 0){
      this.endereco = {
        cep: this.form.value.cep,
        rua: this.form.value.rua,
        numero: this.form.value.numero,
        complemento: this.form.value.complemento,
        bairro: this.form.value.bairro,
        cidade: this.form.value.cidade,
        estado: this.form.value.estado,
        cliente: this.cliente[0].cod_cliente
      };
      this.ofertaService.inserirEndereco(this.endereco)
        .subscribe(
          response => {
              console.log('endereco cadastrado')
          },
          err => {
              this.status = err;
          });
    }
    this.ofertaService.inserirVendas(this.cliente[0].cod_cliente, this.produtoInserido)
      .subscribe(
        response => {
            console.log('venda cadastrada')
        },
        err => {
            this.status = err;
        });;
    debugger;
  }

}
