import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { ClienteService } from '../../services/cliente.service';
import { Cliente } from '../../models/cliente.model';
import { Utilitarios } from '../../shared/Utilitarios';
import { ConfirmationService } from 'primeng/api';




@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  clientes: string[];
  cols: any[];
  formulario: FormGroup;


  constructor(
    private formBuilder: FormBuilder,
    private service: ClienteService,
    private router: Router,
    private confirmationService: ConfirmationService
  ) { }

  ngOnInit() {
    this.cols = [
      { field: 'Cnpj', header: 'Cnpj' },
      { field: 'Razao', header: 'Razão Social' },
      { field: 'Fantasia', header: 'Fantasia' }
      //{ field: 'IM', header: 'IM' },
      //{ field: 'IE', header: 'IE' },
      //{ field: 'Obs', header: 'Obs' }
    ];
    this.clienteLista();
  }

  onSubmit(form) {

  }
  preparaForm() {

    this.formulario = this.formBuilder.group({
      Cnpj: [null, Validators.required],
      Razao: [null, Validators.required],
      Fantasia: [null, Validators.required],
      IE: [null],
      IM: [null],
      Obs:[null]
    });
  }
  clienteLista() {
    this.service.getAll().subscribe(
      (res) => { this.clientes = res },
      error => {

      }
      );
  }
  novoRegistro() {
    this.router.navigate(['/cliente/new']);
  }
  editarRegistro(cliente: Cliente) {
    let util = new Utilitarios();
    let cnpj = util.soNumerosCnpj(cliente.Cnpj);
    this.router.navigate(['/cliente/' + cnpj]);
  }
  excluirRegistro(cliente: Cliente) {
    this.confirm(cliente);
  }
  confirm(cliente) {
    this.confirmationService.confirm({
      message: 'Confirma a Exclusão do Cliente ' + cliente.Fantasia + ' ?',
      header: 'Excluir Registro',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.service.delete(cliente).subscribe(
          (res) => {
            this.clienteLista();
          },
          error => {  }
        );
      },
      reject: () => {

      }
    });
  }

}
