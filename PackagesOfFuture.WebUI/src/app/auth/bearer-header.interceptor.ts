export interface Auth {
}
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpRequest, HttpHandler } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthorizationService } from './authorization.service';

@Injectable()
export class BearerHeaderInterceptor implements HttpInterceptor {
  constructor(private auth: AuthorizationService) {
    
  }

  intercept(httpRequest: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.auth.rawToken

    if (!token) {
      return next.handle(httpRequest)
    }

    const bearerToken = `Bearer ${token}`

    return next.handle(
      httpRequest.clone({ 
        setHeaders: {
          "Authorization": bearerToken
        } 
      })
    )
  }
}