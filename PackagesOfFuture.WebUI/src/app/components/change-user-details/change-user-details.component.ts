import { Component } from '@angular/core';
import { ChangeUserDetailsDto, UserActionDto, UserActionType } from 'src/app/models/users';
import { UserService } from 'src/app/services/user/user-service';

@Component({
  selector: 'pof-change-user-details',
  templateUrl: './change-user-details.component.html',
  styleUrls: ['./change-user-details.component.sass']
})
export class ChangeUserDetailsComponent {
  formTitle: string = 'Edytuj dane'
  actionButtonName: string = 'Edytuj'
  actionType: UserActionType = UserActionType.ChangeDetails

  constructor(private users: UserService) { }

  public onFormSubmitted(event$: UserActionDto): void {
    this.users.changeUserDetails(event$ as ChangeUserDetailsDto).subscribe(_ => {})
  }
}
