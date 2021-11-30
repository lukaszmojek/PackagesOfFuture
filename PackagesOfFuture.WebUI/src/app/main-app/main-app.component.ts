import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { IAuthState } from '../auth/auth.reducer';

@Component({
  selector: 'pof-main-app',
  templateUrl: './main-app.component.html',
  styleUrls: ['./main-app.component.sass']
})
export class MainAppComponent {
  public isLoggedIn$: Observable<boolean>

  constructor(private store: Store<IAuthState>) { 
    this.isLoggedIn$ = store.select(x => x.isLoggedIn)
  }
}
