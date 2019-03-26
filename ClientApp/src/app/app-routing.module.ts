import { PreventAuthComponentGuard } from './core/guards/prevent-auth-component.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';

export const routers: Routes = [
  { path: 'auth', loadChildren: './modules/auth/auth.module#AuthModule', canActivate: [PreventAuthComponentGuard] },
  { path: 'home', loadChildren: './modules/home/home.module#HomeModule', canActivate: [AuthGuard] },
  { path: '', pathMatch: 'full', redirectTo: 'home' }
]

@NgModule({
  imports: [
    RouterModule.forRoot(routers)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class AppRoutingModule { }
