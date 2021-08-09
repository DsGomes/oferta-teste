import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { CadastroClienteComponent } from './cadastro-cliente/cadastro-cliente.component';
import { OfertaClienteComponent } from './oferta-cliente/oferta-cliente.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'cadastro-cliente', component: CadastroClienteComponent },
  { path: 'ofertas', component: OfertaClienteComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
