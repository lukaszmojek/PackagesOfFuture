import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { IAuthState } from 'src/app/auth/auth.reducer';
import { User } from 'src/app/models/users';
import { UserService } from 'src/app/services/user/user-service';
import { IApplicationState } from 'src/app/state';
import StoreConnectedComponent from 'src/app/utilities/store-connected.component';

@Component({
  selector: 'pof-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.sass']
})
export class UserDetailsComponent extends StoreConnectedComponent<IApplicationState> implements OnInit {
  @Input() title: string = 'Zarejestruj się'
  
  public userDetailsFormGroup: FormGroup

  public user: User 
  private userId: string

  constructor(store$: Store<{auth: IAuthState}>, private formBuilder: FormBuilder, private users: UserService) {
    super(store$)
    this.createUserDetailsForm()
  }

  public ngOnInit(): void {
    this.subscribeToUserDetails()
  }

  private createUserDetailsForm(): void {
    this.userDetailsFormGroup = this.formBuilder.group({
      'firstName': this.formBuilder.control('', [Validators.required]),
      'lastName': this.formBuilder.control('', [Validators.required]),
      'email': this.formBuilder.control('', [Validators.required, Validators.email]),
      'password': this.formBuilder.control('', [Validators.required]),
      'repeatPassword': this.formBuilder.control('', [Validators.required]),
      'street': this.formBuilder.control('', [Validators.required]),
      'houseAndFlatNumber': this.formBuilder.control('', [Validators.required]),
      'postalCode': this.formBuilder.control('', [Validators.required]),
      'city': this.formBuilder.control('', [Validators.required]),
      'type': this.formBuilder.control('', [Validators.required]),
    })
  }

  private subscribeToUserDetails(): void {
    this.users.getUserById(1).subscribe(user => {
      this.user = user
      
      if (!!this.userId) {
        this.fillFormWithUserDetails()
      }
    })
  }

  private fillFormWithUserDetails(): void {
    this.userDetailsFormGroup.get('firstName')?.setValue(this.user.firstName)
    this.userDetailsFormGroup.get('lastName')?.setValue(this.user.lastName)
    this.userDetailsFormGroup.get('email')?.setValue(this.user.email)
    this.userDetailsFormGroup.get('street')?.setValue(this.user.address.street)
    this.userDetailsFormGroup.get('houseAndFlatNumber')?.setValue(this.user.address.houseAndFlatNumber)
    this.userDetailsFormGroup.get('postalCode')?.setValue(this.user.address.postalCode)
    this.userDetailsFormGroup.get('city')?.setValue(this.user.address.city)
    this.userDetailsFormGroup.get('type')?.setValue(this.user.type)
    this.userDetailsFormGroup.updateValueAndValidity()
  }
}
