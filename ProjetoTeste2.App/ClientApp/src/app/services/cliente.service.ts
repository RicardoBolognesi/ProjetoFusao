import { Injectable } from '@angular/core';
import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { map } from 'rxjs/operator/map';
import { catchError, take } from 'rxjs/operators';
import { Observable } from 'rxjs';


import { Cliente } from '../models/cliente.model';
import { BaseService } from './base.service';
import { AppSettings } from '../app.settings';


@Injectable()
export class ClienteService extends  BaseService {


  getAll() {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };

    const url = AppSettings.GET_ALL_CLIENTE_URL;

    return this.http.get(url).pipe(
      take(1),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );

  }
  create(cliente: Cliente) {

    //const httpOptions: { headers; observe; } = {
    //  headers: new HttpHeaders({
    //    'Content-Type': 'application/json',
    //    'Accept': 'application/json'
    //  }),
    //  observe: 'response'
    //};

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const url = AppSettings.CREATE_CLIENTE_URL;

    return this.http.post(url, cliente, httpOptions).pipe(
      take(1),
      catchError((res: HttpErrorResponse)=> this.handleError(res))
      );

  }
  delete(cliente: Cliente) {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const url = AppSettings.DELETE_CLIENTE_URL;

    return this.http.post(url, cliente, httpOptions).pipe(
      take(1),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );


  }
  edit(id: string) {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };

    const url = AppSettings.EDIT_CLIENTE_URL;

    return this.http.get(`${url}/${id}`).pipe(
      take(1),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }
  update(cliente: Cliente) {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const url = AppSettings.UPDATE_CLIENTE_URL;

    return this.http.post(url, cliente, httpOptions).pipe(
      take(1),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }
 
}
