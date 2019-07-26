import { Injectable } from '@angular/core';

import { AppSettings } from '../app.settings';
import { BaseResponse } from '../models/base-response.model';
import { map, take } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';
import { EnderecoTipo } from '../models/endereco-tipo.model';
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class EnderecotipoService extends BaseService {

  getAll(): Observable<EnderecoTipo> {
    const url = AppSettings.GET_ALL_ENDERECO_TIPO_URL;

    return this.http.get<BaseResponse>(url).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      //catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }

  //getById(id: string): Observable<EnderecoTipo> {
  //  const url = AppSettings.EDIT_ENDERECO_TIPO_URL;

  //  return this.http.get<BaseResponse>(`${url}/${id}`).pipe(
  //    map((res: BaseResponse) => this.extractData(res)),
  //    //catchError((res: HttpErrorResponse) => this.handleError(res))
  //  );
  //}
  //update(enderecoTipo: EnderecoTipo): Observable<EnderecoTipo> {

  //  const httpOptions = {
  //    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
  //  };
  //  const url = AppSettings.UPDATE_ENDERECO_TIPO_URL;

  //  return this.http.post<BaseResponse>(url, enderecoTipo, httpOptions).pipe(
  //    map((res: BaseResponse) => this.extractData(res)),
  //    //catchError((res: HttpErrorResponse) => this.handleError(res))
  //  );
  //}
  delete(enderecoTipo: EnderecoTipo): Observable<EnderecoTipo> {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const url = AppSettings.DELETE_ENDERECO_TIPO_URL;

    return this.http.post<BaseResponse>(url, enderecoTipo, httpOptions).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      //catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }
  //novo(enderecoTipo: EnderecoTipo): Observable<EnderecoTipo> {

  //  const httpOptions = {
  //    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
  //  };
  //  const url = AppSettings.CREATE_ENDERECO_TIPO_URL;

  //  return this.http.post<BaseResponse>(url, enderecoTipo, httpOptions).pipe(
  //    map((res: BaseResponse) => this.extractData(res)),
  //    //catchError((res: HttpErrorResponse) => this.handleError(res))
  //  );
  //}
  getById(id: string) {

    const url = AppSettings.EDIT_ENDERECO_TIPO_URL;
    return this.http.get(`${url}/${id}`);
  }
  create(tipo) {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };

    const url = AppSettings.CREATE_ENDERECO_TIPO_URL;

    return this.http.post(url, tipo, httpOptions).pipe(take(1));
  }

  update(tipo) {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const url = AppSettings.UPDATE_ENDERECO_TIPO_URL;

    return this.http.put(url, tipo, httpOptions).pipe(take(1));

  }
}
