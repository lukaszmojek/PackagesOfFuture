import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Store } from '@ngrx/store';
import { AuthActions } from 'src/app/auth/auth.actions';
import { IAuthState } from 'src/app/auth/auth.reducer';
import { selectIsLoggedIn } from 'src/app/auth/auth.selectors';
import { PackagesService } from 'src/app/services/packages.service';
import { IApplicationState } from 'src/app/state';
import StoreConnectedComponent from 'src/app/utilities/store-connected.component';

class SimpleErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    if (!control) {
      return false
    }

    const isSubmitted = form && form.submitted
    const isControlChangedOrSubmitted = control.dirty || control.touched || isSubmitted
    
    return !!(control && control.invalid && isControlChangedOrSubmitted)
  }
}

@Component({
  selector: 'pof-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent extends StoreConnectedComponent<IApplicationState> implements OnInit {
  public emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  public passwordFormControl = new FormControl('', [Validators.required]);
  
  public matcher = new SimpleErrorStateMatcher();
  
  public isLoggedIn = false

  public get areEmailAndPasswordValid(): boolean {
    return this.emailFormControl.valid && this.passwordFormControl.valid
  }

  constructor(store$: Store<{auth: IAuthState}>, private packages: PackagesService) {
    super(store$)
  }

  ngOnInit(): void {
    this.subscribeToIsLoggedIn()
  }

  public logIn() {
    this.store$.dispatch(
      AuthActions.logIn({
        email: this.emailFormControl.value,
        password: this.passwordFormControl.value
      })
    )
  }

  public logOut() {
    this.store$.dispatch(
      AuthActions.logOut()
    )
  }

  public getPackages(): void {
    this.packages.getPackagesByAdmin().subscribe(response => {
      console.log(response)
    })
  }

  private subscribeToIsLoggedIn(): void {
    this.safeSelect$(selectIsLoggedIn).subscribe(isLoggedIn => {
      this.isLoggedIn = isLoggedIn
    })
  }
}
