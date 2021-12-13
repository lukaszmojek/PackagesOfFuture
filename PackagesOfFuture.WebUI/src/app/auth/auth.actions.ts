import { createAction, props } from '@ngrx/store';

const login = createAction(
  '[Login Page] Login requested',
  props<{ email: string; password: string }>()
);

const loginSuccess = createAction(
  '[Login Page] Login success',
  props<{ token: string }>()
);

const loginFailed = createAction('[Login Page] Login failed');

const logout = createAction('[Login Page] Logout requested');

const logoutSuccess = createAction('[Login Page] Logout success');

const logoutFailed = createAction('[Login Page] Logout failed');

export const AuthActions = {
  login,
  loginSuccess,
  loginFailed,
  logout,
  logoutSuccess,
  logoutFailed,
}
