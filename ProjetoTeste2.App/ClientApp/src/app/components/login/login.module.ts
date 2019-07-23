import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { LoginComponent } from './login.component';
import { PanelModule } from 'primeng/components/panel/panel';
import { InputTextModule } from 'primeng/components/inputtext/inputtext';
import { PasswordModule } from 'primeng/components/password/password';
import { ButtonModule } from 'primeng/components/button/button';
import { AccountService } from '../../services/account.service';
import { TooltipModule } from "primeng/components/tooltip/tooltip"
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { MessageService } from 'primeng/api';


@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    PanelModule,
    InputTextModule,
    ButtonModule,
    PasswordModule,
    TooltipModule,
    MessagesModule,
    MessageModule
  ],
  declarations: [LoginComponent],
  exports: [LoginComponent],
  providers:[AccountService,MessageService]
})
export class LoginModule { }
