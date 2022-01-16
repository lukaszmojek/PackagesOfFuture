import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddEditDrone, DroneDto, RegisterDroneDto } from 'src/app/models/drone';
import { SortingDto } from 'src/app/models/sorting';

@Component({
  selector: 'pof-add-drone-modal',
  templateUrl: './add-drone-modal.component.html',
  styleUrls: ['./add-drone-modal.component.sass']
})
export class AddDroneModalComponent implements OnInit {
  public form: FormGroup;
  public model: string;
  public range: number;
  public sortingId: number;
  public sortings: SortingDto[];
  public drone: DroneDto;

  public editMode: boolean = false;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: AddEditDrone,
    public dialogRef: MatDialogRef<AddDroneModalComponent>,
  ) { }

  ngOnInit(): void {
    this.setFormData();

    this.drone = this.data.drone;
    this.sortings = this.data.sortings;

    if (this.drone) {
      this.editMode = true;
      this.setDataToEdit();
    } else {
      this.editMode = false;
    }
  }

  private setFormData() {
    this.form = new FormGroup({
      model: new FormControl(null, Validators.required),
      range: new FormControl(null, Validators.required),
      sorting: new FormControl(null, Validators.required),
    })
  }

  private setDataToEdit() {
    this.model = this.drone.model;
    this.range = this.drone.range;
    const sorting = this.sortings.find(x => x.name === this.drone.sortingName)
    if (sorting) {
      this.sortingId = sorting.id;
    }
  }

  public getNewDroneData(): RegisterDroneDto {
    return {
      model: this.model,
      range: this.range,
      sortingId: this.sortingId
    }
  }

  public canEdit(): boolean {
    if (this.form.invalid) {
      return false;
    }

    if (this.model !== this.drone.model) {
      return true;
    }

    if (this.range !== this.drone.range) {
      return true;
    }

    const sortingId = this.sortings.find(x => x.name === this.drone.sortingName)?.id;

    if (this.sortingId !== sortingId) {
      return true;
    }

    return false;
  }
}
