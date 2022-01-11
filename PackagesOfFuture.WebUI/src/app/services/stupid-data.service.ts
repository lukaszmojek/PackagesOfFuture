import { Injectable } from '@angular/core';
import { PaymentType } from '../models/payments';

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
