import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient} from '@angular/common/http';
import { BaseResponse } from '../models/base-response.model';
import { HttpErrorResponse } from '@angular/common/http';
import { RequestInfo } from '../models/request-info.model';
import { AppSettings } from '../app.settings';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
//import { throwError } from 'rxjs';

@Injectable()
export class BaseService {

  router: Router;
  http: HttpClient;

  constructor(private _router: Router, private _http: HttpClient) {
    this.router = _router;
    this.http = _http;
  }

  public extractData(res: BaseResponse) {
    if (res.IsSuccess) {
      let requestInfo: RequestInfo = new RequestInfo();
      requestInfo.ConnectionId = res.ConnectionId;
      requestInfo.LocalIpAddress = res.LocalIpAddress;
      requestInfo.LocalPort = res.LocalPort;
      requestInfo.RemoteIpAddress = res.RemoteIpAddress;
      requestInfo.RemotePort = res.RemotePort;
      requestInfo.RequestPath = res.RequestPath;
      requestInfo.SignedInTime = res.SignedInTime;
      AppSettings.RequestInfoEvent.next(requestInfo);
      return JSON.parse(res.Response);
    } else {
      return JSON.parse(res.Response);
    }
  }

  public handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      //Ocorreu um erro do lado do cliente ou de rede. Lidar com isso
      return new ErrorObservable('Verifique sua conexão de rede !.');
    } else {
      //O back-end retornou um código de resposta malsucedido
      //O corpo de resposta pode conter pistas sobre o que deu errado

      // acesso negado ou proibido
      if (error.status === 403 || error.status === 401) {
        //window.location.replace(window.location.href);
        //this.router.navigateByUrl('/login')
        this.router.navigateByUrl('/login');
      }

    }
    return new ErrorObservable('Avisar o Administrador do Sistema.');
  }
}
