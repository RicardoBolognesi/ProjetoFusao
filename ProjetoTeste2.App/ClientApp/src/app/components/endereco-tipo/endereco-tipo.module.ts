import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';


import { TableModule } from 'primeng/table';
import { PanelModule } from 'primeng/components/panel/panel';
import { TooltipModule } from 'primeng/components/tooltip/tooltip';
import { InputTextModule } from 'primeng/components/inputtext/inputtext';
import { EnderecoTipoRouting } from './endereco-tipo-routing';
import { EnderecoTipoComponent } from './endereco-tipo.component';
import { EnderecoTipoFormComponent } from './endereco-tipo-form/endereco-tipo-form.component';
import { EnderecotipoService } from '../../services/enderecotipo.service';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/components/button/button';
import { ConfirmDialogModule } from "primeng/confirmdialog";
import { ToastService } from '../../shared/toast.service';


@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    TableModule,
    PanelModule,
    TooltipModule,
    EnderecoTipoRouting,
    InputTextModule,
    ButtonModule,
    MessagesModule,
    MessageModule,
    ConfirmDialogModule
  ],
  declarations: [EnderecoTipoComponent, EnderecoTipoFormComponent],
  exports: [EnderecoTipoComponent],
  providers:[EnderecotipoService,MessageService,ToastService]

})
export class EnderecoTipoModule { }
