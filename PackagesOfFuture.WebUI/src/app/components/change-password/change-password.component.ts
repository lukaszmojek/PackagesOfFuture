import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { AuthorizationService } from 'src/app/auth/authorization.service';
import { UserService } from 'src/app/services/user.service';

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
  selector: 'pof-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.sass']
})
export class ChangePasswordComponent implements OnInit {
  public oldPasswordFormControl = new FormControl('', [Validators.required]);
  public newPasswordFormControl = new FormControl('', [Validators.required]);
  public newRePasswordFormControl = new FormControl('', [Validators.required]);

  public matcher = new SimpleErrorStateMatcher();

  private currentUserId: number = 0;
  

  constructor(
    private userService: UserService,
    private authorizationService: AuthorizationService
   ) { }

  ngOnInit(): void {
    this.getCurrentUserId();
  }

  public getCurrentUserId() {
    this.currentUserId = this.authorizationService.currentUserId();
  }

  public get arePasswordsValid(): boolean {
    return this.oldPasswordFormControl.valid && 
           this.newPasswordFormControl.valid &&
           this.newRePasswordFormControl.valid;
  }

  public async changePassword() {
    const newPassword = this.newPasswordFormControl.value;
    const oldPassword = this.oldPasswordFormControl.value;
    this.userService.changePassword(this.currentUserId, oldPassword, newPassword).subscribe( 
      () => {
        this.resetForms();
      },
      () => {
      }
    )
  }

  private resetForms() {
    this.oldPasswordFormControl.reset();
    this.newPasswordFormControl.reset();
    this.newRePasswordFormControl.reset();
  }
}
