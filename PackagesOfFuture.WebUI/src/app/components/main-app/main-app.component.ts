import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { IAuthState } from 'src/app/auth/auth.reducer';
import { selectIsLoggedIn } from 'src/app/auth/auth.selectors';
import { IApplicationState } from 'src/app/state';
import StoreConnectedComponent from 'src/app/utilities/store-connected.component';

@Component({
  selector: 'pof-main-app',
  templateUrl: './main-app.component.html',
  styleUrls: ['./main-app.component.sass']
})
export class MainAppComponent extends StoreConnectedComponent<IApplicationState> {
  public isLoggedIn: boolean

  constructor(store: Store<{auth: IAuthState}>) {
    super(store)
    this.safeSelect$(selectIsLoggedIn).subscribe(isLoggedIn => {
      this.isLoggedIn = isLoggedIn
    })
  }
}
