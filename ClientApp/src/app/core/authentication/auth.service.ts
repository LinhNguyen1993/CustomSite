import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt'
import { BehaviorSubject } from 'rxjs';

import { environment } from '../../../environments/environment';


@Injectable()
export class AuthService {

  user: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  private jwtHelper: JwtHelperService = new JwtHelperService();

  constructor(private router: Router) {
    this.setUser();
  }

  setAuth(token: string) {
    localStorage.setItem(environment.tokenName, token);
    this.setUser();
  }

  getToken() {
    return localStorage.getItem(environment.tokenName);
  }

  removeToken() {
    localStorage.removeItem(environment.tokenName);
  }

  setUser() {
    let user: any;
    try {
      let token = this.getToken();
      user = this.jwtHelper.decodeToken(token);
    }
    catch (ex) {
      user = null;
    }
    this.user.next(user);
  }

  isAuthenticated(): boolean {
    let token = this.getToken();
    try {
      let isExpired = this.jwtHelper.isTokenExpired(token);
      if (isExpired) {
        this.removeToken();
        this.user.next(null);
        return false;
      }

      return true;
    }
    catch (ex) {
      this.removeToken();
      this.user.next(null);
      return false;
    }
  }
}

