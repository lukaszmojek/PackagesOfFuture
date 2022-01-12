import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { IAuthState } from 'src/app/auth/auth.reducer';
import { CreateAddressDto } from 'src/app/models/addresses';
import { UserActionType, ChangeUserDetailsDto, RegisterUserDto, User, UserType, UserActionDto } from 'src/app/models/users';
import { UserService } from 'src/app/services/user.service';
import { IApplicationState } from 'src/app/state';
import StoreConnectedComponent from 'src/app/utilities/store-connected.component';

class UserDetailsErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    if (!control) {
      return false
    }

    const isSubmitted = form && form.submitted
    const isControlChangedOrSubmitted = control.dirty || control.touched || isSubmitted
    
    return !!(control && control.invalid && isControlChangedOrSubmitted)
  }
}

function createSamePasswordValidator(passwordFormControl: AbstractControl): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value;

      if (!value || !passwordFormControl.value) {
        return null;
      }

      const arePasswordsIdentical = value === passwordFormControl.value

      return arePasswordsIdentical ? null : { notIdentical: true }
  }
}
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

  private userId: string

  public userDetailsFormGroup: FormGroup
  public matcher = new UserDetailsErrorStateMatcher();
  public user: User 
  public selectedUserType: number

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

  public formControl(controlName: string): FormControl {
    return this.userDetailsFormGroup.get(controlName) as FormControl
  }

  constructor(
    store$: Store<{auth: IAuthState}>, 
    private formBuilder: FormBuilder,
    private users: UserService,
    private route: ActivatedRoute
  ) {
    super(store$)
    this.subscribeToUserIdFromRoute()
    this.formSubmitted = new EventEmitter<any>()
  }

  public ngOnInit(): void {
    this.createUserDetailsForm()
    this.subscribeToUserDetails()
  }

  public emitSubmittedEvent(): void {
    this.formSubmitted.emit(this.getUserDetailsForAction())
  }

  private createUserDetailsForm(): void {
    const passwordFormControl = this.formBuilder.control('', !this.isChangeUserDetailsAction ? [Validators.required] : [])
    const repeatPasswordFormControl = this.formBuilder.control('', !this.isChangeUserDetailsAction ? [Validators.required, createSamePasswordValidator(passwordFormControl)] : [])
    
    this.userDetailsFormGroup = this.formBuilder.group({
      'firstName': this.formBuilder.control('', [Validators.required]),
      'lastName': this.formBuilder.control('', [Validators.required]),
      'email': this.formBuilder.control('', [Validators.required, Validators.email]),
      'password': passwordFormControl,
      'repeatPassword': repeatPasswordFormControl,
      'street': this.formBuilder.control('', [Validators.required]),
      'houseAndFlatNumber': this.formBuilder.control('', [Validators.required]),
      'postalCode': this.formBuilder.control('', [Validators.required]),
      'city': this.formBuilder.control('', [Validators.required]),
    })

    passwordFormControl.valueChanges.subscribe(_ => {
      repeatPasswordFormControl.updateValueAndValidity()
    })
  }

  private subscribeToUserIdFromRoute() {
    this.route.params.subscribe(params => {
      this.userId = params['id']
      // console.log(this.userId)
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
    this.selectedUserType = this.user.type
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
      id: this.userId,
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

  private getAddUserDto(): RegisterUserDto {
    return {
      firstName: this.controlValue<string>('firstName'),
      lastName: this.controlValue<string>('lastName'),
      email: this.controlValue<string>('email'),
      password: this.controlValue<string>('password'),
      type: this.selectedUserType,
      address: {
        houseAndFlatNumber: this.controlValue<string>('houseAndFlatNumber'),
        postalCode: this.controlValue<string>('postalCode'),
        city: this.controlValue<string>('city'),
        street: this.controlValue<string>('street'),
      } as CreateAddressDto
    } as RegisterUserDto
  }

  private controlValue<T>(controlName: string): T {
    return this.formControl(controlName)?.value as T
  } 
}
