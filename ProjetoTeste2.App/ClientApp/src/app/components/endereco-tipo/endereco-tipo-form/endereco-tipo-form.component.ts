import { Component, OnInit,ViewContainerRef, OnDestroy } from '@angular/core';

import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EnderecotipoService } from '../../../services/enderecotipo.service';
import { Subscription } from 'rxjs';
import { EnderecoTipo } from '../../../models/endereco-tipo.model';
import { ToastsManager } from 'ng2-toastr';
import { ToastService } from '../../../shared/toast.service';

@Component({
  selector: 'app-endereco-tipo-form',
  templateUrl: './endereco-tipo-form.component.html',
  styleUrls: ['./endereco-tipo-form.component.css'],
  providers: [ ToastService ]

})
export class EnderecoTipoFormComponent implements OnInit
{

  formulario: FormGroup;
  id: string = "";
  inscr: Subscription;
  

  constructor(
    private formBuilder: FormBuilder,
    private routerAtive: ActivatedRoute,
    private router: Router,
    private service: EnderecotipoService,
    //public toastr: ToastsManager,
    //vcr: ViewContainerRef,
    private toastService: ToastService
  ) {
    //this.toastr.setRootViewContainerRef(vcr);
  }

  ngOnInit() {
    this.preparaForm();
    this.obterId();
    if (typeof this.id == "undefined") {

    } else {
      this.carregarDados();
    }
  }

  onSubmit(form) {
    if (form.enderecoTipoId !== "0") {
      this.update(form);
    } else {
      this.create(form);
    }
  }
  preparaForm() {

    this.formulario = this.formBuilder.group({
      enderecoTipoId: [null, Validators.required],
      descricaoTipo: [null, Validators.required]
    });
  }
  obterId() {
    this.inscr = this.routerAtive.params.subscribe(
      (params: any) => {
        this.id = params["id"];
      }
    );
  }
  create(form) {
    this.service.create(form).subscribe(
      success => {
        //this.showSuccess();
        this.toastService.showCreateSuccess();
        this.formulario.reset();
        setTimeout(() => {
            this.router.navigate(['tipoendereco']);
          },
          3500);
      },
      error => {
        //this.showError();
        this.toastService.showCreateError();
      }
      );
  }
  update(form) {
    this.service.update(form).subscribe(
      success => {
        //this.showSuccess();
        this.toastService.showEditSuccess();
        this.formulario.reset();
        setTimeout(() => {
            this.router.navigate(['tipoendereco']);
          },
          3500);
      },
      error => {
        //this.showError();
        this.toastService.showEditError();
      }
      );
  }
  carregarDados() {

    this.service.getById(this.id).subscribe(
      (res: EnderecoTipo) => {
        this.updateForm(res);
      }, error => {
        console.log(error);
      });
  }
  updateForm(tipo: EnderecoTipo) {
    this.formulario.patchValue({
      enderecoTipoId: tipo.EnderecoTipoId,
      descricaoTipo: tipo.DescricaoTipo
    });
  }

  //showSuccess() {
  //  this.toastr.success('Registro adicionado com sucesso !', 'Inclusão');
  //}
  //showError() {
  //  this.toastr.error('Houve um erro ao adicionar o registro !', 'Erro de Inclusão');
  //}
}
