import * as JsPDF from "jspdf";

export class Report extends JsPDF {


  constructor() {
    super();
  }
  
  cabecalho() {
    let html = '<table>' +
      '<tr style="text-align: center"><b>Relatório Presencial de Consulta</b></tr>' +
      '</table>' +
      '<hr>';
    this.fromHTML(html, 10, 10);
  }
  rodape() {

  }
}
