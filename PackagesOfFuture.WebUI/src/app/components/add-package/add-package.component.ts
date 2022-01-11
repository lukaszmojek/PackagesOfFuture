import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PaymentType } from 'src/app/models/payments';
import { ServiceModel } from 'src/app/models/services';
import { PackagesService } from 'src/app/services/packages/packages.service';
import { StupidDataService } from 'src/app/services/stupid-data.service';

@Component({
  selector: 'pof-add-package',
  templateUrl: './add-package.component.html',
  styleUrls: ['./add-package.component.sass']
})
export class AddPackageComponent implements OnInit {
  public form!: FormGroup;
  public packageServiceTypes!: ServiceModel[];
  public paymentTypes!: PaymentType[];
  
  constructor(
    private packageService: PackagesService) { }

  ngOnInit(): void {
    this.getPackageService();
    this.form = new FormGroup({
      typeOfPackage: new FormControl(null, Validators.required),
      typeOfCourier: new FormControl(null, Validators.required),
      typeOfPayment: new FormControl(null, Validators.required)
    })
  }

  private async getPackageService() {
    this.packageServiceTypes = await this.packageService.getServices().toPromise();
    console.log(this.packageServiceTypes)
  }

  private getPaymentTypes() {
    // this.paymentTypes = this.stupidDataService.getPaymentTypes();
  }
}
