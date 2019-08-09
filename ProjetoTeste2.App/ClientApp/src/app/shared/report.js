"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var JsPDF = require("jspdf");
var Report = /** @class */ (function (_super) {
    __extends(Report, _super);
    function Report() {
        return _super.call(this) || this;
    }
    Report.prototype.cabecalho = function () {
        var html = '<table>' +
            '<tr style="text-align: center"><b>Relatório Presencial de Consulta</b></tr>' +
            '</table>' +
            '<hr>';
        this.fromHTML(html, 10, 10);
    };
    Report.prototype.rodape = function () {
    };
    return Report;
}(JsPDF));
exports.Report = Report;
//# sourceMappingURL=report.js.map