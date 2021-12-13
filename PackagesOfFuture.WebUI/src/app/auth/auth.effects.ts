import { Injectable } from "@angular/core";
import { AuthenticationService } from "./authentication.service";
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { AuthActions } from "./auth.actions";
import { exhaustMap, catchError, map } from "rxjs/operators";
import { of } from "rxjs";

@Injectable()
export class AuthEffects {
  logIn$ = createEffect(() => this.actions$.pipe(
    ofType(AuthActions.login),
    exhaustMap(action => this.auth.logIn$(action.email, action.password)
      .pipe(
        map(response => AuthActions.loginSuccess({token: response.content.token})),
        catchError(error => of(AuthActions.loginFailed()))
      ))
    )
  );

  constructor(
    private actions$: Actions,
    private auth: AuthenticationService
  ) {}
}