import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ClienteComponent } from './cliente.component';
import { ClienteFormComponent } from './cliente-form/cliente-form.component';



const ClienteRoutes = [
  { path: 'cliente', component: ClienteComponent },
  { path: 'cliente/new', component: ClienteFormComponent },
  { path: 'cliente/:id', component: ClienteFormComponent }

];

@NgModule({
  imports: [RouterModule.forChild(ClienteRoutes)],
  exports:[RouterModule]
})
export class ClienteRouting {
  
}
