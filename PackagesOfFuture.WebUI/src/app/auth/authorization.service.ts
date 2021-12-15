import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { IAuthState } from './auth.reducer';
import { selectToken } from './auth.selectors';
import jwtDecode from "jwt-decode";
import { EMPTY, Observable, of } from 'rxjs';
import { DecodedToken } from './decoded-token';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  private _decodedToken!: DecodedToken;

  constructor(private store$: Store<{auth: IAuthState}>) {
    this.store$.select(selectToken).subscribe(token => {
      if (!token) {
        return
      }
      
      this._decodedToken = jwtDecode<DecodedToken>(token)
    })
  }

  private role$(): Observable<string> {
    if (!this._decodedToken) {
      return EMPTY
    }

    return of(this._decodedToken.role)
  }
}
