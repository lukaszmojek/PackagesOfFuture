import { Injectable } from '@angular/core';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  //TODO: potentially move authentication logic to store
  private _token: string = 'dupa123'

  public isLoggedIn$ = of(!!this._token)
  
  constructor() { }
}
