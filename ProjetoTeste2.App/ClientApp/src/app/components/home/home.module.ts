import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



import { MenubarModule } from 'primeng/components/menubar/menubar';
import { ButtonModule } from 'primeng/components/button/button';
import { HomeComponent } from './home.component';
import { HomeNavigmenuComponent } from './home-navigmenu/home-navigmenu.component';
import { ConfirmDialogModule } from "primeng/confirmdialog";

@
NgModule({
  imports: [
    CommonModule,
    MenubarModule,
    ButtonModule,
    ConfirmDialogModule
  ],
  declarations: [HomeComponent, HomeNavigmenuComponent],
  providers: [],
  exports: [HomeComponent,HomeNavigmenuComponent]

})
export class HomeModule { }
