import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AppSettings } from '../common/appsettings';
import { IApiResponse, ITokenResponse } from './models';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private readonly localStorageTokenKey = 'pof_token_key'

  public get tokenEntryExistsInLocalStorage(): boolean {
    return !!localStorage.getItem(this.localStorageTokenKey)
  }

  constructor(private http: HttpClient) { }

  public logIn$(email: string, password: string): Observable<IApiResponse<ITokenResponse>> {
    const request = {
      email: email, 
      password: password
    }

    return this.http.post<IApiResponse<ITokenResponse>>(AppSettings.authEndpoint, request).pipe(
      tap(tokenResponse => {
        localStorage.setItem(this.localStorageTokenKey, tokenResponse.content.token)
      })
    )
  }

  public logOut$(): Observable<any> {
    localStorage.removeItem(this.localStorageTokenKey)
    
    //TODO: Think how to change that to different observable,
    //TODO: there might be something more appropiate to use here
    return of('')
  }
}
