import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CourierType } from 'src/app/models/couriers';
import { AppSettings } from '../common/appsettings';

@Injectable({
  providedIn: 'root'
})
export class PackagesService {

  constructor(private http: HttpClient) { }

  public getPackages(): Observable<any> {
    return this.http.get(AppSettings.packagesEndpoint)
  }

  public getServices(): Observable<CourierType[]> {
    return this.http.get<CourierType[]>(AppSettings.servicesEndpoint)
  }
}
