import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CourierType } from 'src/app/models/couriers';
import { AppSettings } from '../common/appsettings';
import { ChangePackageStatusDto, ChangeStatusPaymentDto, PackageDto, RegisterPackageDto } from '../models/packages';

@Injectable({
  providedIn: 'root'
})
export class PackagesService {

  constructor(private http: HttpClient) { }

  public getServices(): Observable<CourierType[]> {
    return this.http.get<CourierType[]>(AppSettings.servicesEndpoint)
  }

  public registerPackage(registerPackage: RegisterPackageDto): any {
    return this.http.post(AppSettings.packagesEndpoint, registerPackage)
  }

  public getPackagesByUserId(userId: number): Observable<PackageDto[]> {
    return this.http.get<PackageDto[]>(`${AppSettings.packagesEndpoint}/user-packages/${userId}`)
  }

  public getPackagesByAdmin(): Observable<PackageDto[]> {
    return this.http.get<PackageDto[]>(AppSettings.packagesEndpoint)
  }

  public changePaymentStatus(paymentDto: ChangeStatusPaymentDto): Observable<any> {
    return this.http.post(`${AppSettings.paymentEndpoint}/change-status`, paymentDto);
  }

  public changePackageStatus(request: ChangePackageStatusDto): Observable<any> {
    return this.http.post(`${AppSettings.packagesEndpoint}/changeStatus`, request);
  }
}
