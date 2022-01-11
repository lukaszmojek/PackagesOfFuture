import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
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
  public isLoggedIn$: Observable<boolean>

  //TODO: Change to restict type of the store  
  constructor(private store: Store<{auth: IAuthState}>) {
    super(store)
    this.isLoggedIn$ = this.safeSelect$(selectIsLoggedIn)
  }
}
