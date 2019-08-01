import { Component, OnInit, ViewContainerRef } from '@angular/core';

import { Subscription } from 'rxjs';
import { AppSettings } from './app.settings';
import { UserIdleService } from 'angular-user-idle';
import { AccountService } from './services/account.service';
import { Router } from '@angular/router';
import { ToastsManager } from 'ng2-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'app';
  dadosData: any = "São Paulo, 05 de Julho de 2019.";
  logomx: any = "/assets/logomxsystems.png";
  isPageLogin : Subscription;
  mostrarMenu: boolean;
  mostrarRodape: boolean;
  nomeUsuario: string ="";

  constructor(
    public tostr: ToastsManager,
    vcr : ViewContainerRef,
    private userIdle: UserIdleService,
    private service: AccountService,
    private route: Router
  ) {
    this.tostr.setRootViewContainerRef(vcr);
    this.service.nomeDoUsuario.subscribe(nome => this.nomeUsuario = nome);
  }

  ngOnInit() {
    this.dadosData = this.formatarData();
    this.hideMenuRodape();
    this.verificaSessao(this.userIdle);


  }

  formatarData() {
    let data: any = new Date();
    let dia: any = data.getDate();
    let mes: any = (data.getMonth());
    let ano: any = data.getFullYear();
    let diaSemana: any = data.getDay();
    let dataFormatada: any = "";

    let mesExtenso: Array<string> = [
      "Janeiro",
      "Fevereiro",
      "Março",
      "Abril",
      "Maio",
      "Junho",
      "Julho",
      "Agosto",
      "Setembro",
      "Outubro",
      "Novembro",
      "Dezembro"
    ];

    let diaSemanaExtenso: Array<string> = [
      "Domingo",
      "Segunda-Feira",
      "Terça-Feira",
      "Quarta-Feira",
      "Quinta-Feira",
      "Sexta-Feira",
      "Sábado"
    ];

    diaSemana = diaSemanaExtenso[diaSemana].toString();
    mes = mesExtenso[mes].toString();


    dataFormatada = diaSemana + " " + dia + " de " + mes + " de " + ano;

    return dataFormatada.toString();
  }
  hideMenuRodape() {
    this.isPageLogin = AppSettings.IsLoginPageEvent.subscribe(
      (response: any) => {
        setTimeout(() => {
          this.mostrarMenu = response;
          this.mostrarRodape = response;
        });
      },
      error => {
      });
  }

  verificaSessao(userIdle: UserIdleService) {
    //Start watching for user inactivity.
    userIdle.startWatching();
    // Start watching when user idle is starting and reset if user action is there.
    userIdle.onTimerStart().subscribe(count => {
      var eventList = ["click", "mouseover", "keydown", "DOMMouseScroll", "mousewheel",
        "mousedown", "touchstart", "touchmove", "scroll", "keyup"];
      for (let event of eventList) {
        document.body.addEventListener(event, () => userIdle.resetTimer());
      }
    });
    // Start watch when time is up.
    userIdle.onTimeout().subscribe(() => {
      this.signOut();
    });
  }
  signOut() {
    this.service.signOut().subscribe(resp => {
      if (resp) {
        AppSettings.IsLoginPageEvent.next(true);
        AppSettings.IsAuthenticated.next(false);
        this.service.authenticated = false;
        this.route.navigate(['/login']);
      }
    });
  }

}
