import { Component, Input } from '@angular/core';

export enum SnackBarType {
  Success,
  Error
}

@Component({
  selector: 'pof-snackbar-message',
  templateUrl: './snackbar-message.component.html',
  styleUrls: ['./snackbar-message.component.sass']
})
export class SnackbarMessageComponent {
  @Input() message: string
  @Input() type: SnackBarType

  public get isSuccess(): boolean {
    return this.type === SnackBarType.Success
  }

  constructor() { }
}
