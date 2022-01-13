import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PackageStatus } from 'src/app/models/enums';

@Component({
  selector: 'pof-change-package-status-modal',
  templateUrl: './change-package-status-modal.component.html',
  styleUrls: ['./change-package-status-modal.component.sass']
})
export class ChangePackageStatusModalComponent implements OnInit {
  public inDelivery: boolean;
  public delivered: boolean;


  constructor(
    @Inject(MAT_DIALOG_DATA) public status: number,
    public dialogRef: MatDialogRef<ChangePackageStatusModalComponent>,
  ) { }

  ngOnInit(): void {
    this.setData();
  }

  private setData() {
    console.log(this.status)
    if (this.status === PackageStatus.Delivered) {
      this.inDelivery = false;
      this.delivered = false;
    } else if (this.status === PackageStatus.InDelivery) {
      this.inDelivery = false;
      this.delivered = true;
    } else if (this.status === PackageStatus.OnRoute) {
      this.inDelivery = true;
      this.delivered = true;
    }
  }
}
