import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { EnderecoTipoComponent } from './endereco-tipo.component';
import { EnderecoTipoFormComponent } from './endereco-tipo-form/endereco-tipo-form.component';

const EnderecoTipoRoutes = [
  { path: 'tipoendereco', component: EnderecoTipoComponent },
  { path: 'tipoendereco/new', component: EnderecoTipoFormComponent },
  { path: 'tipoendereco/:id', component: EnderecoTipoFormComponent }

  ];

@NgModule({
  imports: [RouterModule.forChild(EnderecoTipoRoutes)],
  exports:[RouterModule]
})
export class EnderecoTipoRouting {
  
}
