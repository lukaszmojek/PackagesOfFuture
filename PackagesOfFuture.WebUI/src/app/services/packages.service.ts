import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CourierType } from 'src/app/models/couriers';
import { AppSettings } from '../common/appsettings';
import { RegisterPackageDto } from '../models/packages';

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

  public registerPackage(registerPackage: RegisterPackageDto): any {
    return this.http.post(AppSettings.packagesEndpoint, registerPackage)
  }
}
