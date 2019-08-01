import { Injectable } from '@angular/core';

import {ToastsManager} from "ng2-toastr";


@Injectable()
export class ToastService {

  

  constructor(public tostr : ToastsManager ) {
  }

  showSuccess() {
    this.tostr.success('Usuário Autenticado !', 'Autenticação');
  }

  showError() {
    this.tostr.error('Usuário ou Senha não confere !', 'Erro de Autenticação');
  }

  showCreateSuccess() {
    this.tostr.success('Registro criado com sucesso !', 'Inclusão');
  }

  showCreateError() {
    this.tostr.error('Houve um erro ao excluir o registro !', 'Exclusão');
  }

  showEditSuccess() {
    this.tostr.success('Registro Atualizado com sucesso !', 'Edição');
  }

  showEditError() {
    this.tostr.error('Houve um erro ao Editar o registro !', 'Edição');
  }
}
