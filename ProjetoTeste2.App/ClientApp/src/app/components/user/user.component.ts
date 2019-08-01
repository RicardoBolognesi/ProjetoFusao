import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { UserService } from '../../services/user.service';
import { ToastsManager } from 'ng2-toastr';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  formulario: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private service: UserService,
    public toastr: ToastsManager,
    vcr: ViewContainerRef
  ) {
    this.toastr.setRootViewContainerRef(vcr);
  }

  ngOnInit() {
    this.createForm();
  }

  onSubmit() {
    this.salvar(this.formulario.value);
  }


  createForm() {
    this.formulario = this.formBuilder.group({
      username: [null, Validators.required],
      email: [null, Validators.required],
      passwordHash: [null, Validators.required],
      confirmPassword: [null, Validators.required]
    });
  }
  salvar(user) {
    this.service.saveUser(user).subscribe((res) => {
        if (res) {
          this.formulario.reset();
          this.showSuccess();
        }
      },
      error => {
        this.showError(error);
      }
    );
  }

  showSuccess() {
    this.toastr.success("Registro gravado com sucesso !", "Inclusão de Usuário !");
  }

  showError(erro) {
    this.toastr.error(erro, "Erro ao Salvar Usuário !");
  }
}
