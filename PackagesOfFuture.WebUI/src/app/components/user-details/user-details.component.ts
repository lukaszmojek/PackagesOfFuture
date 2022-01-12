import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { IAuthState } from 'src/app/auth/auth.reducer';
import { CreateAddressDto } from 'src/app/models/addresses';
import { UserActionType, AddUserDto, ChangeUserDetailsDto, RegisterUserDto, User, UserType, UserActionDto } from 'src/app/models/users';
import { UserService } from 'src/app/services/user/user-service';
import { IApplicationState } from 'src/app/state';
import StoreConnectedComponent from 'src/app/utilities/store-connected.component';

@Component({
  selector: 'pof-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.sass']
})
export class UserDetailsComponent extends StoreConnectedComponent<IApplicationState> implements OnInit {
  @Input() formTitle: string
  @Input() actionButtonName: string
  @Input() actionType: UserActionType

  @Output() formSubmitted: EventEmitter<UserActionDto>

  public userDetailsFormGroup: FormGroup

  public user: User 
  private userId: string

  public get isFormValid(): boolean {
    return this.userDetailsFormGroup.valid
  }

  public get isRegisterUserAction(): boolean {
    return this.actionType === UserActionType.Register
  }

  public get isChangeUserDetailsAction(): boolean {
    return this.actionType === UserActionType.ChangeDetails
  }

  public get isAddUserAction(): boolean {
    return this.actionType === UserActionType.Add
  }

  constructor(
    store$: Store<{auth: IAuthState}>, 
    private formBuilder: FormBuilder,
    private users: UserService,
    private route: ActivatedRoute
  ) {
    super(store$)
    this.createUserDetailsForm()
    this.subscribeToUserIdFromRoute()
    this.formSubmitted = new EventEmitter<any>()
  }

  public ngOnInit(): void {
    this.subscribeToUserDetails()
  }

  public emitSubmittedEvent(): void {
    this.formSubmitted.emit(this.getUserDetailsForAction())
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

  private subscribeToUserIdFromRoute() {
    this.route.params.subscribe(params => {
      this.userId = params['id']
      console.log(this.userId)
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

  private getUserDetailsForAction(): UserActionDto {
    if (this.isRegisterUserAction) {
      return this.getRegisterUserDto()
    }

    if (this.isChangeUserDetailsAction) {
      return this.getChangeUserDetailsDto()
    }

    return this.getAddUserDto()
  }

  private getRegisterUserDto(): RegisterUserDto {
    return {
      firstName: this.controlValue<string>('firstName'),
      lastName: this.controlValue<string>('lastName'),
      email: this.controlValue<string>('email'),
      password: this.controlValue<string>('password'),
      type: UserType.Client,
      address: {
        houseAndFlatNumber: this.controlValue<string>('houseAndFlatNumber'),
        postalCode: this.controlValue<string>('postalCode'),
        city: this.controlValue<string>('city'),
        street: this.controlValue<string>('street'),
      } as CreateAddressDto
    } as RegisterUserDto
  }

  private getChangeUserDetailsDto(): ChangeUserDetailsDto {
    return {
      firstName: this.controlValue<string>('firstName'),
      lastName: this.controlValue<string>('lastName'),
      email: this.controlValue<string>('email'),
      address: {
        houseAndFlatNumber: this.controlValue<string>('houseAndFlatNumber'),
        postalCode: this.controlValue<string>('postalCode'),
        city: this.controlValue<string>('city'),
        street: this.controlValue<string>('street'),
      } as CreateAddressDto
    } as ChangeUserDetailsDto
  }

  private getAddUserDto(): AddUserDto {
    return {
      firstName: this.controlValue<string>('firstName'),
      lastName: this.controlValue<string>('lastName'),
      email: this.controlValue<string>('email'),
      password: this.controlValue<string>('password'),
      type: this.controlValue<number>('type'),
      address: {
        houseAndFlatNumber: this.controlValue<string>('houseAndFlatNumber'),
        postalCode: this.controlValue<string>('postalCode'),
        city: this.controlValue<string>('city'),
        street: this.controlValue<string>('street'),
      } as CreateAddressDto
    } as RegisterUserDto
  }

  private controlValue<T>(controlName: string): T {
    return this.userDetailsFormGroup.get(controlName)?.value as T
  } 
}
