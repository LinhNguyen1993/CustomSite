import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class InterceptorService implements HttpInterceptor {
  intercept(httpRequest: HttpRequest<any>, httpHandler: HttpHandler): Observable<HttpEvent<any>> {
    const token: string = localStorage.getItem(environment.tokenName);

    if (token) {
      httpRequest = httpRequest.clone({ headers: httpRequest.headers.set('Authorization', 'Bearer ' + token) });
    }

    httpRequest = httpRequest.clone({ headers: httpRequest.headers.set('Content-Type', 'application/json',) });

    httpRequest = httpRequest.clone({ headers: httpRequest.headers.set('Accept', 'application/json') });
    return httpHandler.handle(httpRequest);
  }

}
