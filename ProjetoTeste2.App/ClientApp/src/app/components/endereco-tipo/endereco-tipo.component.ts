import { Component, OnInit, ViewContainerRef } from '@angular/core';

import { EnderecotipoService } from '../../services/enderecotipo.service';
import { EnderecoTipo } from '../../models/endereco-tipo.model';
import { Router } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { ToastsManager } from 'ng2-toastr';
import { AppSettings } from '../../app.settings';

@Component({
  selector: 'app-endereco-tipo',
  templateUrl: './endereco-tipo.component.html',
  styleUrls: ['./endereco-tipo.component.css'],
  providers: [ConfirmationService]
})
export class EnderecoTipoComponent implements OnInit {

  enderecoTipos: any;
  cols: any[];
  enderecoTipo: EnderecoTipo;
  id: number;
  

  constructor(
    private service: EnderecotipoService,
    private route: Router,
    private confirmationService: ConfirmationService,
    public toastr: ToastsManager,
    vcr: ViewContainerRef
  ) {this.toastr.setRootViewContainerRef(vcr); }

  ngOnInit() {

    this.cols = [
      { field: 'EnderecoTipoId', header: 'Código' },
      { field: 'DescricaoTipo', header: 'Descrição'}
    ];

    this.carregarTodos();
  }

  carregarTodos() {
    this.service.getAll().subscribe(
      (res) => {
        this.enderecoTipos = res;
      },
      error => {
        console.log(error);
      }
    );

  }

  verRegistro(tipo: EnderecoTipo) {
    AppSettings.TipoOperacao.next(2);
    this.id = tipo.EnderecoTipoId;
    this.route.navigate(['tipoendereco/' + this.id]);
  }

  excluirRegistro(tipo: EnderecoTipo) {
    AppSettings.TipoOperacao.next(3);
    this.confirm(tipo);
  }

  novoRegistro() {
    this.route.navigate(['tipoendereco/new']);
  }
  showSuccess() {
    this.toastr.success('Registro excluído com sucesso !', 'Exclusão');
  }
  showError() {
    this.toastr.error('Houve um erro ao excluir o registro !', 'Erro de Exclusão');
  }
  confirm(tipo) {
    this.confirmationService.confirm({
      message: 'Confirma a Exclusão do item ' + tipo.DescricaoTipo + ' ?',
      header: 'Excluir Registro',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.service.delete(tipo).subscribe(
          (res) => {
            this.showSuccess();
            this.carregarTodos();
          },
          error => { this.showError(); }
        );
      },
      reject: () => {

      }
    });
  }
}
