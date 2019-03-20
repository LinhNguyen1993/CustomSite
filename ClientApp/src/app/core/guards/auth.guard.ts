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
    return this.checkAuth();
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return this.checkAuth();
  }

  private checkAuth() {
    let isAuthenticated = this.auth.isAuthenticated();
    if (isAuthenticated) { return true; }

    this.router.navigate(['/auth']);
    return false;
  }
}
