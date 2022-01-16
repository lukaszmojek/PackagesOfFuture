import { Injectable } from '@angular/core';
import { ParcelType } from '../models/parcels';
import { PaymentType } from '../models/payments';

@Injectable({
  providedIn: 'root'
})
export class StupidDataService {

  constructor() { }

  public getPaymentTypes(): PaymentType[] {
    return [
      {
        id: 1,
        description: "Blik"
      },
      {
        id: 2,
        description: "Czek"
      },
      {
        id: 3,
        description: "Gotówka"
      },
      {
        id: 4,
        description: "Przelew bankowy"
      }
    ];
  }

  public getParcelTypes(): ParcelType[] {
    return [
      {
        id: 1,
        description: "Paczka 1kg",
        height: 10,
        length: 10,
        weight: 1,
        width: 10,
        price: 5
      },
      {
        id: 2,
        description: "Paczka 5kg",
        height: 20,
        length: 20,
        weight: 5,
        width: 20,
        price: 10
      },
      {
        id: 3,
        description: "Paczka 10kg",
        height: 30,
        length: 30,
        weight: 10,
        width: 30,
        price: 15
      }
    ];
  }

}
