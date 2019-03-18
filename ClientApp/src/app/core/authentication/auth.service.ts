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
    this.setUser(localStorage.getItem(environment.tokenName));
  }

  setAuth(token: string) {
    localStorage.setItem(environment.tokenName, token);
    this.setUser(token);
  }
  getToken() {
    return localStorage.getItem(environment.tokenName);
  }

  private setUser(token: string) {
    let user: any;
    try {
      user = this.jwtHelper.decodeToken(token);
    }
    catch (ex) {
      user = null;
    }
    this.user.next(user);
  }
  isAuthenticated(): boolean {
    let token = localStorage.getItem(environment.tokenName);
    try {
      return !this.jwtHelper.isTokenExpired(token);
    }
    catch (ex) {
      return false;
    }
  }
}

