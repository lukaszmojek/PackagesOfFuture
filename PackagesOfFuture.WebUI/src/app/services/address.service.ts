import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from '../common/appsettings';
import { AddressDto } from '../models/address';

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  constructor(private http: HttpClient) { }

  public getAddressByUserId(userId: number): Observable<AddressDto> {
    const url = `${AppSettings.addressEndpoint}/getByUserId/${userId}`

    return this.http.get<AddressDto>(url)
  }
}
