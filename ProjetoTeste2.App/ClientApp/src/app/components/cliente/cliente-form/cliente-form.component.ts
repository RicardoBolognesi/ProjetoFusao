import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

import { ClienteService } from '../../../services/cliente.service';
import { Cliente } from '../../../models/cliente.model';
import { Utilitarios } from '../../../shared/Utilitarios';
import * as JsPDF from "jspdf";
//import { PdfMakeWrapper, Txt }  from "pdfmake-wrapper"


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
  downloadPdf(formulario) {
    let report = new JsPDF("p", "mm", "a4");



    report.setFontSize(12);
    report.setFontStyle("bolditalic");
    report.setFont('helvetica');

    report.text("Cadastro de Cliente", 80, 20);

    report.setLineWidth(0.5);
    report.line(10, 25, 200, 25);


    report.setFontSize(8);
    

    report.setFontStyle("bolditalic");
    report.text("Razão Social : ", 10, 35);
    report.text("Nome Fantasia : ", 10, 40);
    report.text("IM : ", 10, 45);
    report.text("IE : ", 10, 50);
    report.text("Observações : ", 10, 55);

    report.setFontStyle("italic");
    report.text(formulario.Razao, 30, 35);
    report.text(formulario.Fantasia, 33, 40);
    report.text(formulario.IM, 16, 45);
    report.text(formulario.IE, 16, 50);
    report.text(formulario.Obs, 30, 55);

    report.setLineWidth(0.5);
    report.line(10, 282, 200, 282);
    report.text("1", 190, 286);

    report.save("report.pdf");


  }
  //downloadPdfMake(formulario) {
  //  const relatorio = new PdfMakeWrapper();

  //  relatorio.pageOrientation('Portrait');
  //  relatorio.pageMargins([40, 60, 40, 60]);
  //  relatorio.pageSize('A4');
  //  relatorio.defaultStyle({ fontSize: 10, bold: false });

  //  relatorio.add(new Txt('Razão Social : ').bold().italics().end);
  //  relatorio.add(new Txt('Nome Fantasia :' + formulario.Fantasia).bold().italics().end);
  //  relatorio.add(new Txt('IM :' + formulario.IM).bold().italics().end);
  //  relatorio.add(new Txt('IE :' + formulario.IE).bold().italics().end);
  //  relatorio.add(new Txt('Observações :' + formulario.Obs).bold().italics().end);
  //  relatorio.create().open();
  //}
}
