import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { IAuthState } from '../auth/auth.reducer';
import { selectIsLoggedIn } from '../auth/auth.selectors';
import StoreConnectedComponent from '../shared/components/utilities/store-connected.component';
import { IApplicationState } from '../state';

@Component({
  selector: 'pof-main-app',
  templateUrl: './main-app.component.html',
  styleUrls: ['./main-app.component.sass']
})
export class MainAppComponent extends StoreConnectedComponent<IApplicationState> {
  public isLoggedIn$: Observable<boolean>

  //TODO: Change to restict type of the store  
  constructor(private store: Store<{auth: IAuthState}>) {
    super(store)
    this.isLoggedIn$ = this.safeSelect$(selectIsLoggedIn)
  }
}
