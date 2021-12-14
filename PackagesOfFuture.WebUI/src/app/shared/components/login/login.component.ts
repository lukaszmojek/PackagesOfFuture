import { Component } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Store } from '@ngrx/store';
import { AuthActions } from 'src/app/auth/auth.actions';
import { IAuthState } from 'src/app/auth/auth.reducer';
import { IApplicationState } from 'src/app/state';
import StoreConnectedComponent from '../utilities/store-connected.component';

class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted))
  }
}

@Component({
  selector: 'pof-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent extends StoreConnectedComponent<IApplicationState>{
  public emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  public passwordFormControl = new FormControl('', [Validators.required]);

  public matcher = new MyErrorStateMatcher();
  
  public get areEmailAndPasswordValid(): boolean {
    return this.emailFormControl.valid && this.passwordFormControl.valid
  }

  constructor(store$: Store<{auth: IAuthState}>) {
    super(store$)
  }

  public logIn() {
    this.store$.dispatch(
      AuthActions.login({
        email: this.emailFormControl.value,
        password: this.passwordFormControl.value
      })
    )
  }
}
