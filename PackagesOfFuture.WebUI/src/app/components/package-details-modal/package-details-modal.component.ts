import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PackageDto } from 'src/app/models/packages';

@Component({
  selector: 'pof-package-details-modal',
  templateUrl: './package-details-modal.component.html',
  styleUrls: ['./package-details-modal.component.sass']
})
export class PackageDetailsModalComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: PackageDto) { }

  ngOnInit(): void {
  }

}
