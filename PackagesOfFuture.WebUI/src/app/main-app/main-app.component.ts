import { Component } from '@angular/core';
import { AuthenticationService } from '../shared/services/authentication/authentication.service';

@Component({
  selector: 'pof-main-app',
  templateUrl: './main-app.component.html',
  styleUrls: ['./main-app.component.sass']
})
export class MainAppComponent {
  public isLoggedIn$ = this.authentication.isLoggedIn$

  constructor(private authentication: AuthenticationService) { }
}
