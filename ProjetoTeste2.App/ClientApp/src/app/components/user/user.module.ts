import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { PanelModule } from 'primeng/components/panel/panel';
import { InputTextModule } from 'primeng/components/inputtext/inputtext';
import { ButtonModule } from 'primeng/components/button/button';
import { PasswordModule } from 'primeng/components/password/password';
import { UserComponent } from './user.component';
import { UserService } from '../../services/user.service';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { MessageService } from 'primeng/api';




@
NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    PanelModule,
    InputTextModule,
    ButtonModule,
    PasswordModule,
    MessagesModule,
    MessageModule
  ],
  declarations: [UserComponent],
  exports: [UserComponent],
  providers:[UserService, MessageService]
})
export class UserModule { }
