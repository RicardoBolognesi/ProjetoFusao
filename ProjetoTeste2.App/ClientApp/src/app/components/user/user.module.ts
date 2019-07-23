import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { PanelModule } from 'primeng/components/panel/panel';
import { InputTextModule } from 'primeng/components/inputtext/inputtext';
import { ButtonModule } from 'primeng/components/button/button';
import { PasswordModule } from 'primeng/components/password/password';
import { UserComponent } from './user.component';
import { UserService } from '../../services/user.service';




@
NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    PanelModule,
    InputTextModule,
    ButtonModule,
    PasswordModule
  ],
  declarations: [UserComponent],
  exports: [UserComponent],
  providers:[UserService]
})
export class UserModule { }
