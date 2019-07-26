import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/components/common/menuitem';

import { AccountService } from '../../../services/account.service';
import { Router } from '@angular/router';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { AppSettings } from '../../../app.settings';
import { map } from 'rxjs/operator/map';



@Component({
  selector: 'app-home-navigmenu',
  templateUrl: './home-navigmenu.component.html',
  styleUrls: ['./home-navigmenu.component.css'],
  providers: [ConfirmationService]

})
export class HomeNavigmenuComponent implements OnInit {

  items: MenuItem[];

  constructor(
    private service: AccountService,
    private router: Router,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {

    this.items = [
      {
        label: 'Início',
        icon: 'pi pi-fw pi-home',
        routerLink: ['/home']
      },
      {
        label: 'Compras',
        icon: 'pi pi-fw pi-file',
        items: [
          { label: 'Fornecedores', icon: 'pi pi-fw pi-user' },
          { label: 'Cotações', icon: 'pi pi-fw pi-user' },
          { label: 'Pedidos', icon: 'pi pi-fw pi-user' }
        ]
      },
      {
        label: 'Comercial',
        icon: 'pi pi-fw pi-file',
        items: [
          { label: 'Orçamentos', icon: 'pi pi-fw pi-user' },
          { label: 'Ordens Serviço', icon: 'pi pi-fw pi-users' }
        ]
      },
      {
        label: 'Atendimento',
        icon: 'pi pi-fw pi-file',
        items: [
          { label: 'Ordens Serviço', icon: 'pi pi-fw pi-user' },
          { label: 'Tipo Endereço', icon: 'pi pi-fw pi-users', routerLink: ['/tipoendereco'] }
        ]
      },
      {
        label: 'Financeiro',
        icon: 'pi pi-fw pi-file',
        items: [
          { label: 'Contas Pagar', icon: 'pi pi-fw pi-user' },
          { label: 'Contas Receber', icon: 'pi pi-fw pi-users' }
        ]
      },
      {
        label: 'Usuários',
        icon: 'pi pi-fw pi-users',
        items: [
          { label: 'Cadastro', icon: 'pi pi-fw pi-users', routerLink: ['/user'] }
        ]
      }
      //,
      //{
      //  label: 'Sair',
      //  icon: 'pi pi-fw pi-sign-out'
      //}
    ];
  }

  signOut() {
    this.confirm();

  }

  confirm() {
    this.confirmationService.confirm({
      message: 'Sair do Sistema ?',
      header: 'LogOut',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.service.signOut().subscribe(resp => {
          if (resp) {
            AppSettings.IsLoginPageEvent.next(true);
            AppSettings.IsAuthenticated.next(false);
            this.service.authenticated = false;
            this.router.navigate(['/login']);
          }
        });
      },
      reject: () => {

      }
    });
  }

}
