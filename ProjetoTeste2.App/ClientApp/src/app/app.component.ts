import { Component, OnInit, ViewContainerRef } from '@angular/core';

import { Subscription } from 'rxjs';
import { AppSettings } from './app.settings';
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
  nomeUsuario: string ="Usuário Logado";

  constructor(
    public toastr: ToastsManager,
    vcr: ViewContainerRef
  ) { this.toastr.setRootViewContainerRef(vcr); }

  ngOnInit() {
    this.dadosData = this.formatarData();
    this.hideMenuRodape();
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
  onNomeUsuario(evento) {
    this.nomeUsuario = evento.UserName;
  }



}
