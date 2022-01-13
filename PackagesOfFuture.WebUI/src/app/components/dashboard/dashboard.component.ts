import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { IAuthState } from 'src/app/auth/auth.reducer';
import { AuthorizationService } from 'src/app/auth/authorization.service';
import { IApplicationState } from 'src/app/state';
import StoreConnectedComponent from 'src/app/utilities/store-connected.component';

@Component({
  selector: 'pof-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.sass']
})
export class DashboardComponent extends StoreConnectedComponent<IApplicationState> implements OnInit {
  public get isAdministartor(): boolean {
    return this.auth.isAdministrator()
  }

  constructor(store$: Store<{auth: IAuthState}>, private auth: AuthorizationService ) {
    super(store$)
  }

  ngOnInit(): void {
  }
}
