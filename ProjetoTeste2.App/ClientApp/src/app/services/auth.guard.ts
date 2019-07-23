import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs'
import { AccountService } from './account.service';
import { of } from 'rxjs/observable/of';
import { Response } from '@angular/http';
import { UserAuthenticated } from '../models/user-authenticated.model';
import { AppSettings } from '../app.settings';

@Injectable()
export class AuthGuard implements CanActivate {

  message: string;
  authenticated: boolean = false;

  constructor(private accountService: AccountService, private route: Router) {
  }

  //canActivate(
  //  next: ActivatedRouteSnapshot,
  //  state: RouterStateSnapshot): Observable<boolean> | boolean {
  //  return this.accountService.getSignedInUser().pipe(
  //    map((user) => {
  //      console.log(user);
  //      return true;
  //    }),
  //    catchError((error) => {
  //      console.log(error);
  //      this.route.navigate(['login']);
  //      return of(false);
  //    }));
  //}

  canActivate(next: ActivatedRouteSnapshot,state: RouterStateSnapshot): Observable<boolean> | boolean {

    //return (this.accountService.obterUsuarioLogado().subscribe((userAuthenticated : UserAuthenticated )=> {
    //  if (userAuthenticated.Authenticated) {
    //    console.log(userAuthenticated.Authenticated);
    //   return true;
    //  } else {
    //    AppSettings.IsLoginPageEvent.next(true);
    //    console.log(userAuthenticated.Authenticated);
    //    this.route.navigate(['/login']);
    //    return false;
    //  }
    //})) as any;

    if (this.accountService.authenticated) {
      return true;
    }
    this.route.navigate(['/login']);
    return false;
  }
}
