import { NgModule, Injectable } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthGuard } from './core/guards/auth.guard';

export const routers: Routes = [
  { path: 'auth', loadChildren: './modules/auth/auth.module#AuthModule', canActivate: [AuthGuard] },
  { path: 'home', loadChildren: './modules/home/home.module#HomeModule', canLoad: [AuthGuard] },
  { path: '', pathMatch: 'full', redirectTo: 'home' }
]

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  intercept(httpRequest: HttpRequest<any>, httpHandler: HttpHandler): Observable<HttpEvent<any>> {
    // add authorization header with jwt token if available                
    httpRequest = httpRequest.clone({
      setHeaders: {
        Authorization: `Bearer ${localStorage.getItem(environment.tokenName)}`,
        "Content-Type": "application/json",
      }
    });
    return httpHandler.handle(httpRequest);
  }
}

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
