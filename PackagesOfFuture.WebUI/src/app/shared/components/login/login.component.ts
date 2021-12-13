import { Component } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { AuthenticationService } from 'src/app/auth/authentication.service';

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
export class LoginComponent {
  public emailFormControl = new FormControl('')//, [Validators.required, Validators.email]);
  public passwordFormControl = new FormControl('')//, [Validators.required]);

  public matcher = new MyErrorStateMatcher();
  
  public get areEmailAndPasswordValid(): boolean {
    return this.emailFormControl.valid && this.passwordFormControl.valid
  }

  constructor(private auth: AuthenticationService) { }

  public logIn() {
    this.auth.logIn$('dawid@gmail.com', 'test123').subscribe(x => {
      console.log(x)
    })
  }
}
