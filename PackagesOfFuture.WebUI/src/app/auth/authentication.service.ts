import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { AppSettings } from '../common/appsettings';
import { IApiResponse, ITokenResponse } from './models';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(private http: HttpClient) { }

  public logIn$(email: string, password: string): Observable<IApiResponse<ITokenResponse>> {
    const request = {
      email: email, 
      password: password
    }

    return this.http.post<IApiResponse<ITokenResponse>>(AppSettings.authEndpoint, request)
  }
}
