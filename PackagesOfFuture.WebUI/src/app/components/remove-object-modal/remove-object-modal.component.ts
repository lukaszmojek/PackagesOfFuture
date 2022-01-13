import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'pof-remove-object-modal',
  templateUrl: './remove-object-modal.component.html',
  styleUrls: ['./remove-object-modal.component.sass']
})
export class RemoveObjectModalComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<RemoveObjectModalComponent>,
  ) { }

  ngOnInit(): void {
  }
}
