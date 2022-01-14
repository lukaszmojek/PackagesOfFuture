import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarRef } from '@angular/material/snack-bar';
import { of, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { SnackbarMessageComponent, SnackBarType } from '../components/snackbar-message/snackbar-message.component';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {
  private durationInSeconds = 2
  
  constructor(private snackbar: MatSnackBar) { }

  displayCustomSnackbar(message: string, type: SnackBarType): void {
    let snackbarRef = this.snackbar.openFromComponent(SnackbarMessageComponent, {
      duration: this.durationInSeconds
    })
    
    snackbarRef.instance.message = message
    snackbarRef.instance.type = type
  }

  displaySnackbar(message: string): void {
    let snackbarRef = this.snackbar.open(message, 'OK', {
      duration: this.durationInSeconds * 1000
    })
  }
}
