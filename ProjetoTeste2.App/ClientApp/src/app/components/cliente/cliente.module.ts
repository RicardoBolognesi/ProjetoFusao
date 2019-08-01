import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { InputTextModule } from 'primeng/components/inputtext/inputtext';
import { ButtonModule } from 'primeng/components/button/button';
import { PanelModule } from 'primeng/components/panel/panel';
import { MessageModule } from 'primeng/message';
import { MessagesModule } from 'primeng/messages';
import { TooltipModule } from 'primeng/components/tooltip/tooltip';
import { ClienteComponent } from './cliente.component';
import { MessageService, ConfirmationService } from 'primeng/api';
import { ReactiveFormsModule } from '@angular/forms';
import { InputTextareaModule } from "primeng/components/inputtextarea/inputtextarea";
import { ClienteService } from '../../services/cliente.service';
import { ClienteFormComponent } from './cliente-form/cliente-form.component';
import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { InputMaskModule } from 'primeng/components/inputmask/inputmask';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    InputTextModule,
    ButtonModule,
    PanelModule,
    MessageModule,
    MessagesModule,
    TooltipModule,
    InputTextareaModule,
    TableModule,
    ConfirmDialogModule,
    InputMaskModule
  ],
  declarations: [ClienteComponent, ClienteFormComponent],
  exports: [ClienteComponent],
  providers:[MessageService, ClienteService,ConfirmationService]
})
export class ClienteModule { }
