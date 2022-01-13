import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddressDto } from 'src/app/models/address';
import { AddChangeSortingData, AddSortingDto, ChangeSortingDetailsDto } from 'src/app/models/sorting';

@Component({
  selector: 'pof-sorting-modal',
  templateUrl: './sorting-modal.component.html',
  styleUrls: ['./sorting-modal.component.sass']
})
export class SortingModalComponent implements OnInit {
  public form: FormGroup;
  public editMode: boolean;

  public name: string;
  public street: string;
  public houseNumber: string;
  public postalCode: string;
  public city: string;

  private sortingToEdit: ChangeSortingDetailsDto;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: AddChangeSortingData,
    public dialogRef: MatDialogRef<SortingModalComponent>,
  ) { }

  ngOnInit(): void {
    this.setFormData();
    if (this.data.editMode) {
      this.editMode = true;
      this.sortingToEdit = this.data.sortingToEdit;
      this.setDataToEdit();
    } else {
      this.editMode = false;
    }
  }

  private setFormData() {
    this.form = new FormGroup({
      name: new FormControl(null, Validators.required),
      street: new FormControl(null, Validators.required),
      houseNumber: new FormControl(null, Validators.required),
      postalCode: new FormControl(null, Validators.required),
      city: new FormControl(null, Validators.required),
    })
  }

  private setDataToEdit() {
    this.name = this.sortingToEdit.name;
    this.houseNumber = this.sortingToEdit.address.houseAndFlatNumber;
    this.city = this.sortingToEdit.address.city;
    this.postalCode = this.sortingToEdit.address.postalCode;
    this.street = this.sortingToEdit.address.street;
  }

  public canEdit(): boolean {
    if (this.form.invalid) {
      return false;
    }

    if (this.name !== this.sortingToEdit.name) {
      return true;
    }

    if (this.houseNumber !== this.sortingToEdit.address.houseAndFlatNumber) {
      return true;
    }

    if (this.city !== this.sortingToEdit.address.city) {
      return true;
    }

    if (this.postalCode !== this.sortingToEdit.address.postalCode) {
      return true;
    }

    if (this.street !== this.sortingToEdit.address.street) {
      return true;
    }

    return false;
  }

  private getAddress(): AddressDto {
    return {
      street: this.street,
      houseAndFlatNumber: this.houseNumber,
      city: this.city,
      postalCode: this.postalCode,
    }
  }

  public getChangeSortingData(): ChangeSortingDetailsDto{
    const address = this.getAddress();

    return {
      id: this.sortingToEdit.id,
      name: this.name,
      address: address
    }
  }

  public getAddSortingData(): AddSortingDto{
    const address = this.getAddress();

    return {
      name: this.name,
      address: address
    }
  }
}
