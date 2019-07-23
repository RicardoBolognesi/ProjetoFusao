import { Injectable } from '@angular/core';

import { ToastsManager } from 'ng2-toastr';




@Injectable()
export class ToastService {

  constructor(public toastr : ToastsManager) { }

  showSuccess() {
    this.toastr.success('Usuário Autenticado !', 'Autenticação');
  }

  showError() {
    this.toastr.error('Usuário ou Senha não confere !', 'Erro de Autenticação');
  }

  showCreateSuccess() {
    this.toastr.success('Registro criado com sucesso !', 'Inclusão');
  }

  showCreateError() {
    this.toastr.error('Houve um erro ao excluir o registro !', 'Exclusão');
  }

  showEditSuccess() {
    this.toastr.success('Registro Atualizado com sucesso !', 'Edição');
  }

  showEditError() {
    this.toastr.error('Houve um erro ao Editar o registro !', 'Edição');
  }
}
