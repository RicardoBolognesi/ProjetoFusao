import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


//import { RequestInfoComponent } from './components/request-info/request-info.component';
import { LoginComponent } from './components/login/login.component';
//import { RoleComponent } from './components/role/role.component';
import { AuthGuard } from './services/auth.guard';
import { UserComponent } from './components/user/user.component';
import { HomeComponent } from './components/home/home.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard]},
  { path: 'login', component: LoginComponent },
  { path: 'user', component: UserComponent },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard]}
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
