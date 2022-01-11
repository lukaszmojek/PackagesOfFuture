import { Injectable } from '@angular/core';
import { ParcelType } from '../models/parcel-type';
import { PaymentType } from '../models/payment-type';

@Injectable({
  providedIn: 'root'
})
export class StupidDataService {

  constructor() { }

  public getPaymentTypes(): PaymentType[] {
    return [
      {
        id: 1,
        description: "Przelew"
      },
      {
        id: 2,
        description: "Karta"
      },
      {
        id: 3,
        description: "Blik"
      },
      {
        id: 4,
        description: "Za pobraniem"
      }
    ];
  }

  public getParcelTypes(): ParcelType[] {
    return [
      {
        id: 1,
        description: "Paczka 1kg",
        price: 10
      },
      {
        id: 1,
        description: "Paczka 5kg",
        price: 15
      },
      {
        id: 1,
        description: "Paczka 10kg",
        price: 20
      }
    ];
  }

}
