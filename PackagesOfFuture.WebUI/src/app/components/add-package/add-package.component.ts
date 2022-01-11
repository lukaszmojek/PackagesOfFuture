import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ParcelType } from 'src/app/models/parcel-type';
import { PaymentType } from 'src/app/models/payment-type';
import { CourierType } from 'src/app/models/service-model';
import { PackagesService } from 'src/app/services/packages/packages.service';
import { StupidDataService } from 'src/app/services/stupid-data.service';

@Component({
  selector: 'pof-add-package',
  templateUrl: './add-package.component.html',
  styleUrls: ['./add-package.component.sass']
})
export class AddPackageComponent implements OnInit {
  public form: FormGroup;
  public courierTypes: CourierType[];
  public paymentTypes: PaymentType[];
  public parcelTypes: ParcelType[];

  
  constructor(
    private packageService: PackagesService,
    private stupidDataService: StupidDataService) { }

  ngOnInit(): void {
    this.getPackageService();
    this.getPaymentTypes();
    this.getParcelTypes();
    this.form = new FormGroup({
      typeOfParcel: new FormControl(null, Validators.required),
      typeOfCourier: new FormControl(null, Validators.required),
      typeOfPayment: new FormControl(null, Validators.required)
    })
  }

  private async getPackageService() {
    this.courierTypes = await this.packageService.getServices().toPromise();
    console.log(this.courierTypes)
  }

  private getPaymentTypes() {
    this.paymentTypes = this.stupidDataService.getPaymentTypes();
  }

  private getParcelTypes() {
    this.parcelTypes = this.stupidDataService.getParcelTypes();
  }
}
