import { createReducer, on } from '@ngrx/store';
import * as AuthActions from './auth.actions';

export const authFeatureKey = 'auth'

export const initialState: IAuthState = {
  isLoggedIn: true,
  isActionInProgress: false,
}

export interface IAuthState {
  // token?: string
  isLoggedIn: boolean,
  isActionInProgress: boolean
}

const _authReducer = createReducer(
  initialState,
  on(AuthActions.login, (state) => ({
    ...state,
    isActionInProgress: true
  })),
  on(AuthActions.loginSuccess, (state) => ({
    ...state,
    // token: 
    isLoggedIn: true,
    isActionInProgress: false
  })),
  on(AuthActions.loginFailed, (state) => ({
    ...state,
    isActionInProgress: false
  })),
  on(AuthActions.logout, (state) => ({
    ...state,
    isActionInProgress: true
  })),
  on(AuthActions.logoutSuccess, (state) => ({
    ...state,
    // token: undefined,
    isLoggedIn: false,
    isActionInProgress: false
  })),
  on(AuthActions.logoutFailed, (state) => ({
    ...state,
    isActionInProgress: false
  })),
)

export function authReducer(state: IAuthState = initialState, action: any) {
  return _authReducer(state, action);
}