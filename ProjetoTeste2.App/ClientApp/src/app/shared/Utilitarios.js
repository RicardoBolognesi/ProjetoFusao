"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var forms_1 = require("@angular/forms");
var Utilitarios = /** @class */ (function () {
    function Utilitarios() {
    }
    Utilitarios.prototype.soNumerosCnpj = function (cnpj) {
        var result = cnpj.replace('/', '');
        result = result.replace('.', '');
        result = result.replace('.', '');
        result = result.replace('-', '');
        return result;
    };
    Utilitarios.prototype.validarCnpj = function (cnpj) {
        var tamanho;
        var numeros;
        var digitos;
        var soma;
        var pos;
        var resultado;
        cnpj = cnpj.replace(/[^\d]+/g, '');
        if (cnpj === '')
            return false;
        if (cnpj.length !== 14)
            return false;
        // Elimina CNPJs invalidos conhecidos
        if (cnpj === "00000000000000" ||
            cnpj === "11111111111111" ||
            cnpj === "22222222222222" ||
            cnpj === "33333333333333" ||
            cnpj === "44444444444444" ||
            cnpj === "55555555555555" ||
            cnpj === "66666666666666" ||
            cnpj === "77777777777777" ||
            cnpj === "88888888888888" ||
            cnpj === "99999999999999")
            return false;
        // Valida DVs
        tamanho = (cnpj.length - 2);
        numeros = cnpj.substring(0, tamanho);
        digitos = cnpj.substring(tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (var i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado !== digitos.charAt(0))
            return false;
        tamanho = tamanho + 1;
        numeros = cnpj.substring(0, tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (var i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado !== digitos.charAt(1))
            return false;
        return true;
    };
    Utilitarios.prototype.validarForm = function (formulario) {
        var _this = this;
        Object.keys(formulario.controls).forEach(function (campo) {
            var controle = formulario.get(campo);
            controle.markAsDirty();
            if (controle instanceof forms_1.FormGroup) {
                _this.validarForm(controle);
            }
        });
    };
    return Utilitarios;
}());
exports.Utilitarios = Utilitarios;
//# sourceMappingURL=Utilitarios.js.map