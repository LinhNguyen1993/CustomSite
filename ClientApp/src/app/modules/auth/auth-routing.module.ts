import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent,
    data: { title: 'Log In' }
  },
  {
    path: 'register',
    component: RegisterComponent,
    data: { title: 'Register' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule {
  static components = [
    LoginComponent,
    RegisterComponent
  ];
}
