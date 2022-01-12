import { Component } from '@angular/core';
import { RegisterUserDto, UserActionDto, UserActionType } from 'src/app/models/users';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'pof-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.sass']
})
export class RegisterUserComponent {
  formTitle: string = 'Zarejestruj się'
  actionButtonName: string = 'Zarejestruj'
  actionType: UserActionType = UserActionType.Register

  constructor(private users: UserService) { }

  public onFormSubmitted(event$: UserActionDto): void {
    this.users.registerUser(event$ as RegisterUserDto).subscribe(_ => {})
  }
}
