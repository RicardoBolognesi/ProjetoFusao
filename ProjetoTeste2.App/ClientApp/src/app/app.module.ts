import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { InputTextModule } from 'primeng/components/inputtext/inputtext';
import { ButtonModule } from 'primeng/components/button/button';
import { PanelModule } from 'primeng/components/panel/panel';
import { PasswordModule } from 'primeng/components/password/password';
import { MenubarModule } from 'primeng/components/menubar/menubar';
import { LoginModule } from './components/login/login.module';
import { routing } from './app.routing';
import { UserModule } from './components/user/user.module';
import { HomeModule } from './components/home/home.module';
import { ToastModule, ToastOptions } from 'ng2-toastr/ng2-toastr';
import { TableModule  } from 'primeng/table';
import { EnderecoTipoModule } from './components/endereco-tipo/endereco-tipo.module';
import { EnderecoTipoRouting } from './components/endereco-tipo/endereco-tipo-routing';
import { MessageService } from 'primeng/api';
import { AuthGuard } from './services/auth.guard';


export class CustomOption extends ToastOptions {
  positionClass: 'toast-bottom-full-width';
  animate = 'flyRight'; // you can override any options available
  showCloseButton = true;
  toastLife = 3000;
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    routing,
    InputTextModule,
    ButtonModule,
    PanelModule,
    PasswordModule,
    MenubarModule,
    LoginModule,
    UserModule,
    HomeModule,
    ToastModule.forRoot(),
    TableModule,
    EnderecoTipoModule,
    EnderecoTipoRouting
  ],
  providers: [
    {
      provide: ToastOptions,
      useClass: CustomOption,
    },
    MessageService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
