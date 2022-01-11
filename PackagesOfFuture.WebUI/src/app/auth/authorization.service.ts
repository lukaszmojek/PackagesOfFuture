import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { IAuthState } from './auth.reducer';
import { selectToken } from './auth.selectors';
import jwtDecode from "jwt-decode";
import { DecodedToken } from './decoded-token';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  private _rawToken: string = ''
  private _decodedToken!: DecodedToken;

  public get rawToken(): string {
    return this._rawToken
  }

  public get isAuthorized(): boolean {
    return !!this._rawToken
  }

  constructor(private store$: Store<{auth: IAuthState}>) {
    this.store$.select(selectToken).subscribe(token => {
      this._rawToken = token

      if (!token) {
        return
      }

      this._decodedToken = jwtDecode<DecodedToken>(token)
    })
  }

  public role(): string {
    if (!this._decodedToken) {
      return ''
    }

    return this._decodedToken.role;
  }

  public currentUserId(): number {
    if (!this._decodedToken) {
      return 0;
    }

    return this._decodedToken.id;
  }
}
