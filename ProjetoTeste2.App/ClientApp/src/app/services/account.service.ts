import { HttpHeaders, HttpErrorResponse ,HttpResponse} from '@angular/common/http';
import { map, take, tap } from 'rxjs/operators';
import { Observable } from 'rxjs'
import { AppSettings } from '../app.settings';
import { BaseResponse } from '../models/base-response.model';
import { SignIn } from '../models/sign-in.model';
import { BaseService } from '../services/base.service';
import { Response } from '@angular/http';
import { UserAuthenticated } from '../models/user-authenticated.model';
import { of } from 'rxjs/observable/of';

export class AccountService extends BaseService {

  authenticated: boolean = false;
  statusResposta: Response;
  userAuthenticated: UserAuthenticated;

  signIn(singInDTO: SignIn): Observable<boolean> {

    return this.login(singInDTO).pipe(
      map((resp: Response) => {
        this.authenticated = resp.ok;
        return resp.ok;
      })
    );
  }

  login(singInDTO: SignIn): Observable<any> {
    const httpOptions: { headers; observe; } = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      }),
      observe: 'response'
    };
    //const httpOptions = {
    //  headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' }),
    //  observe:'response'
    //};
    const url = AppSettings.SIGN_IN_URL;

    return this.http.post<any>(url, singInDTO, httpOptions);
  }

  //signOut(): Observable<string> {
  //  const url = AppSettings.SIGN_OUT_URL;

  //  this.authenticated = false;
  //  return this.http.get<BaseResponse>(url).pipe(
  //    map((res: BaseResponse) => this.extractData(res)),
  //    /*catchError((res: HttpErrorResponse) => this.handleError(res))*/
  //  );
  //}
  signOut() : Observable<boolean> {
    return this.out().pipe(
      map((resp: Response) => { return resp.ok;})
    );
  }

  out(): Observable<any> {
    const httpOptions: { headers; observe; } = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      }),
      observe: 'response'
    };

    const url = AppSettings.SIGN_OUT_URL;
    return this.http.get<any>(url, httpOptions);
  }
  //getSignedInUser(): Observable<string> {
  //  const url = AppSettings.GET_SIGNED_IN_USER;

  //  return this.http.get<BaseResponse>(url).pipe(
  //    map((res: BaseResponse) => this.extractData(res)),
  //    //catchError((res: HttpErrorResponse) => this.handleError(res))
  //  );
  //}

  getSignedInUser(): Observable<boolean> {
    const url = AppSettings.GET_SIGNED_IN_USER;

    return this.http.get<UserAuthenticated>(url).pipe(
      map((user: UserAuthenticated) => {
        return user.Authenticated;
      })
    );
  }

  obterUsuarioLogado() {
    const url = AppSettings.GET_SIGNED_IN_USER;

    return this.http.get<UserAuthenticated>(url).pipe(
      );
  }
  obterNomeUsuario() {
    const url = AppSettings.GET_USERNAME_URL;

    return this.http.get<UserAuthenticated>(url).pipe(
      map((user: UserAuthenticated) => user.UserName)
    );
  }
}
