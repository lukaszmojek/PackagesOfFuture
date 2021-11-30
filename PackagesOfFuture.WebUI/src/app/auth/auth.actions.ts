import { createAction } from '@ngrx/store';

export const login = createAction('[Login Page] Login requested');
export const loginSuccess = createAction('[Login Page] Login success');
export const loginFailed = createAction('[Login Page] Login failed');
export const logout = createAction('[Login Page] Logout requested');
export const logoutSuccess = createAction('[Login Page] Logout success');
export const logoutFailed = createAction('[Login Page] Logout failed');

