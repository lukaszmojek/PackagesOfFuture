import { Component } from '@angular/core';
import { AuthorizationService } from 'src/app/auth/authorization.service';

@Component({
  selector: 'pof-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.sass']
})
export class MenuComponent {
  public get userId(): number {
    return this.auth.currentUserId()
  }

  public get isAdministrator(): boolean {
    return this.auth.isAdministrator()
  }

  constructor(private auth: AuthorizationService) { }
}
