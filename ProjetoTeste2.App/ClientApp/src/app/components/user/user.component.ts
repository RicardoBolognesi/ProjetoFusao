import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  formulario: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private service: UserService
    ) { }

  ngOnInit() {
    this.createForm();
  }

  onSubmit() {
    this.salvar(this.formulario.value);
  }


  createForm() {
    this.formulario = this.formBuilder.group({
      username: [null],
      email: [null],
      password: [null],
      confirmPassword: [null]
    });
  }
  salvar(user) {
    this.service.saveUser(user).subscribe((res) => {
        if (res) {
          this.router.navigate(['/Login']);
        }
      },
      error => {
        console.log(error);
      }
    );
  }
}
