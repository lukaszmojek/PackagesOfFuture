import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { AuthActions } from 'src/app/auth/auth.actions';
import { IAuthState } from 'src/app/auth/auth.reducer';
import { AuthorizationService } from 'src/app/auth/authorization.service';
import { IApplicationState } from 'src/app/state';
import StoreConnectedComponent from 'src/app/utilities/store-connected.component';

@Component({
  selector: 'pof-logged-user',
  templateUrl: './logged-user.component.html',
  styleUrls: ['./logged-user.component.sass']
})
export class LoggedUserComponent extends StoreConnectedComponent<IApplicationState> {
  public get loggedUserName(): string {
    return this.auth.currentUserName()
  }

  constructor(store: Store<{auth: IAuthState}>, private auth: AuthorizationService) {
    super(store)
  }

  public logOut(): void {
    this.store$.dispatch(AuthActions.logOut())
  }
}
