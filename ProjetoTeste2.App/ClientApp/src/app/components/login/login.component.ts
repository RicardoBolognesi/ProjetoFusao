import { Component, OnInit, ViewContainerRef} from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AccountService } from '../../services/account.service';
import { SignIn } from '../../models/sign-in.model';
import { ToastsManager } from 'ng2-toastr';
import { AppSettings } from '../../app.settings';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']

})
export class LoginComponent implements OnInit {

  logomx: any;
  formulario: FormGroup;
  submitted: any = false;
  result: any;
 

  constructor(
    private service: AccountService,
    private formBuilder: FormBuilder,
    private router: Router,
    public toastr: ToastsManager,
    vcr: ViewContainerRef
  ) {
    this.toastr.setRootViewContainerRef(vcr);
  }

  ngOnInit() {
    this.logomx = './assets/logomxsystems.png';
    this.createForm();
  }

  createForm() {
    AppSettings.IsLoginPageEvent.next(true);
    this.formulario = this.formBuilder.group({
      username: [null, Validators.required],
      password: [null, Validators.required]
    });
  }

  onSubmit() {
    this.logIn(this.formulario.value);
  }

  logIn(login: SignIn) {
    this.service.signIn(login).subscribe((res) => {
      if (res) {
        AppSettings.IsLoginPageEvent.next(false);
        AppSettings.IsAuthenticated.next(true);
        this.service.authenticated = true;
        this.obterNomeUsuario();
        this.router.navigate(['/home']);
      }
    },
      error => {
        this.showError();
        console.log(error);
      }
    );
  }

  showSuccess() {
    this.toastr.success('Usuário Autenticado !', 'Autenticação');
  }

  showError() {
    this.toastr.error('Usuário ou Senha não confere !', 'Erro de Autenticação');
  }

  obterNomeUsuario() {
    this.service.obterNomeUsuario().subscribe();
  }
}
