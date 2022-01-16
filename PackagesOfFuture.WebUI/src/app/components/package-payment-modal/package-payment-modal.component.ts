import { Component, OnInit } from '@angular/core';
import { MatDialogRef, } from '@angular/material/dialog';

@Component({
  selector: 'pof-package-payment-modal',
  templateUrl: './package-payment-modal.component.html',
  styleUrls: ['./package-payment-modal.component.sass']
})
export class PackagePaymentModalComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<PackagePaymentModalComponent>,
  ) { }

  ngOnInit(): void {
  }
}
