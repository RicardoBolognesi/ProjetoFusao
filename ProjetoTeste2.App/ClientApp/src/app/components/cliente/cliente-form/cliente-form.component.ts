import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

import { ClienteService } from '../../../services/cliente.service';
import { Cliente } from '../../../models/cliente.model';
import { Utilitarios } from '../../../shared/Utilitarios';


@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.css']
})
export class ClienteFormComponent implements OnInit {

  inscr : Subscription;
  formulario: FormGroup;
  cnpj: any;
  cliente: any;


  constructor(
    private formBuilder: FormBuilder,
    private service: ClienteService,
    private router: Router,
    private routerAtive: ActivatedRoute

  ) { }

  ngOnInit() {

    this.preparaForm();
    this.obterCnpj();
    if (typeof this.cnpj == "undefined") {
      
    } else {
      this.edit(this.cnpj);
    }

  }

  onSubmit(form) {
    if (this.formulario.valid) {
      if (typeof this.cnpj == "undefined") {
        this.create(form);
      } else {
        this.update(form);
      }
    } else {
      let util = new Utilitarios();
      util.validarForm(this.formulario);
    }

  }
  preparaForm() {

    this.formulario = this.formBuilder.group({
      Cnpj: [null, Validators.required],
      Razao: [null, Validators.required],
      Fantasia: [null, Validators.required],
      IE: [null],
      IM: [null],
      Obs: [null]
    });
  }
  obterCnpj() {
    this.inscr = this.routerAtive.params.subscribe(
      (params: any) => {
        this.cnpj = params["id"];
      }
    );
  }
  create(form) {
    this.service.create(form).subscribe(
      (res) => {
        this.formulario.reset();
        this.router.navigate(['/cliente']);
      },
      error => {

      }
    );
  }
  edit(cnpj) {
    this.service.edit(cnpj).subscribe(
      (cliente : Cliente) => {
        this.updateForm(cliente);
      },
      error => {

      }
    );
  }
  update(form) {
    this.service.update(form).subscribe(
      (res) => {
        this.formulario.reset();
        this.router.navigate(['/cliente']);
      },
      error => {

      }
      );
  }
  updateForm(cliente : Cliente) {
    this.formulario.patchValue({
      Cnpj: cliente.Cnpj,
      Razao: cliente.Razao,
      Fantasia: cliente.Fantasia,
      IM: cliente.IM,
      IE: cliente.IE,
      Obs: cliente.Obs
    });
  }
  voltar() {
    this.formulario.reset();
    this.router.navigate(['/cliente']);
  }
}
