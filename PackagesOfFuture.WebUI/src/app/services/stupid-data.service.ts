import { Injectable } from '@angular/core';
import { PaymentType } from '../models/payment-type';

@Injectable({
  providedIn: 'root'
})
export class StupidDataService {

  constructor() { }

  public getPaymentTypes(): PaymentType[] {
    return [
      {
        description: "aasd",
        id: 1
      }
    ];
  }

}
