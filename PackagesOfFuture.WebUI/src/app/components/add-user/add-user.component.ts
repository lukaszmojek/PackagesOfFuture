import { Component,  } from '@angular/core';
import { RegisterUserDto, UserActionDto, UserActionType } from 'src/app/models/users';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'pof-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.sass']
})
export class AddUserComponent {
  formTitle: string = 'Dodaj użytkownika'
  actionButtonName: string = 'Dodaj'
  actionType: UserActionType = UserActionType.Add

  constructor(private users: UserService) { }

  public onFormSubmitted(event$: UserActionDto): void {
    this.users.registerUser(event$ as RegisterUserDto).subscribe(_ => {})
  }
}
