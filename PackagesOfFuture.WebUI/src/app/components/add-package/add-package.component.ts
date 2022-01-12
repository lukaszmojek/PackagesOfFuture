import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ParcelType } from 'src/app/models/parcels';
import { PaymentType } from 'src/app/models/payments';
import { CourierType } from 'src/app/models/couriers';
import { PackagesService } from 'src/app/services/packages.service';
import { StupidDataService } from 'src/app/services/stupid-data.service';
import { AuthorizationService } from 'src/app/auth/authorization.service';
import { AddressService } from 'src/app/services/address.service';
import { Address, AddressDto } from 'src/app/models/address';
import { RegisterPackageDto } from 'src/app/models/packages';

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
  public currentUserAddress: AddressDto;
  public receiverAddress: Address = new Address();
  public amountToPay: number = 0;

  public selectedParcelTypeId: number;
  public selectedPaymentTypeId: number;
  public selectedCourierId: number;

  private selectedParcelType: ParcelType;

  private currentUserId: number;
  
  constructor(
    private packageService: PackagesService,
    private stupidDataService: StupidDataService,
    private authorizationService: AuthorizationService,
    private addressService: AddressService) { }

  async ngOnInit() {
    this.getInitData();
    this.setFormData();
  }

  private async getInitData() {
    this.getPackageService();
    this.getPaymentTypes();
    this.getParcelTypes();
    this.getCurrentUserId();
    this.getCurrentUserAddress();
  }

  private setFormData() {
    this.form = new FormGroup({
      typeOfParcel: new FormControl(null, Validators.required),
      typeOfCourier: new FormControl(null, Validators.required),
      typeOfPayment: new FormControl(null, Validators.required),
      amountToPay: new FormControl({value: null, disabled: true}),
      street: new FormControl({value: null, disabled: true}, Validators.required),
      houseNumber: new FormControl({value: null, disabled: true}, Validators.required),
      postalCode: new FormControl({value: null, disabled: true}, Validators.required),
      city: new FormControl({value: null, disabled: true}, Validators.required),

      receiverStreet: new FormControl(null, Validators.required),
      receiverHouseNumber: new FormControl(null, Validators.required),
      receiverPostalCode: new FormControl(null, Validators.required),
      receiverCity: new FormControl(null, Validators.required),
    })
  }

  private async getPackageService() {
    this.courierTypes = await this.packageService.getServices().toPromise();
  }

  private getPaymentTypes() {
    this.paymentTypes = this.stupidDataService.getPaymentTypes();
  }

  private getParcelTypes() {
    this.parcelTypes = this.stupidDataService.getParcelTypes();
  }

  private getCurrentUserId() {
    this.currentUserId = this.authorizationService.currentUserId();
  }

  private async getCurrentUserAddress() {
    this.currentUserAddress = await this.addressService.getAddressByUserId(this.currentUserId).toPromise();

    this.form.controls.street.setValue(this.currentUserAddress.street);
    this.form.controls.postalCode.setValue(this.currentUserAddress.postalCode);
    this.form.controls.city.setValue(this.currentUserAddress.city);
    this.form.controls.houseNumber.setValue(this.currentUserAddress.houseAndFlatNumber);
  }

  private async resetFormAfterAddPackage() {
    this.form.reset();
    await this.getCurrentUserAddress();
  }

  public onSelectChange(event: any) {

    this.amountToPay = 0;
    if (this.selectedParcelTypeId) {
      const selectedParcelType = this.parcelTypes.find(x => x.id === this.selectedParcelTypeId);
      if (selectedParcelType) {
        this.amountToPay += selectedParcelType.price;
        this.selectedParcelType = selectedParcelType;
      }
    }

    if (this.selectedCourierId) {
      const selectedCourier = this.courierTypes.find(x => x.id === this.selectedCourierId);
      if (selectedCourier) {
        this.amountToPay += selectedCourier.price;
      }
    }
  }

  public async addPackage() {

    const registerPackage: RegisterPackageDto = {
      deliveryAddress: this.currentUserAddress,
      receiveAddress: this.receiverAddress,
      serviceId: this.selectedCourierId,
      payment: {
        type: this.selectedParcelTypeId,
        amount: this.amountToPay
      },
      package: {
        height: this.selectedParcelType.height,
        length: this.selectedParcelType.length,
        weight: this.selectedParcelType.weight,
        width: this.selectedParcelType.width,
      }
    }

    await this.packageService.registerPackage(registerPackage).toPromise();
    this.resetFormAfterAddPackage()
  }
}
