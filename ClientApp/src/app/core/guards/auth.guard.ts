import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, CanLoad, Route } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../authentication/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanLoad {
  constructor(private auth: AuthService, private router: Router) { }

  canLoad(route: Route): boolean | Observable<boolean> | Promise<boolean> {
    return this.checkLogin(`/${route.path}`);
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return this.checkLogin(state.url);
  }

  private checkLogin(url: string) {
    let isAuthenticated = this.auth.isAuthenticated();
    if (isAuthenticated) {
      if (url === '/auth') {
        this.router.navigate(['/home']);
        return false;
      }
      return true;
    } else {
      if (url === '/auth') {
        return true;
      }
      this.router.navigate(['/auth']);
      return false;
    }
  }
}
