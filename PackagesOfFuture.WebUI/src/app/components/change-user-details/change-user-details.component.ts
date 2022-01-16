import { Component } from '@angular/core';
import { AuthorizationService } from 'src/app/auth/authorization.service';
import { ChangeUserDetailsDto, UserActionDto, UserActionType } from 'src/app/models/users';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'pof-change-user-details',
  templateUrl: './change-user-details.component.html',
  styleUrls: ['./change-user-details.component.sass']
})
export class ChangeUserDetailsComponent {
  formTitle: string = 'Edytuj dane'
  actionButtonName: string = 'Edytuj'
  actionType: UserActionType = UserActionType.ChangeDetails

  public get isAdministrator(): boolean {
    return this.auth.isAdministrator()
  }

  constructor(private users: UserService, private auth: AuthorizationService) { }

  public onFormSubmitted(event$: UserActionDto): void {
    this.users.changeUserDetails(event$ as ChangeUserDetailsDto).subscribe(_ => {})
  }
}
