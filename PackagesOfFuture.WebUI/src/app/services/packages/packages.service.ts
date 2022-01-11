import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceModel } from 'src/app/models/services';
import { AppSettings } from '../../common/appsettings';

@Injectable({
  providedIn: 'root'
})
export class PackagesService {

  constructor(private http: HttpClient) { }

  public getPackages(): Observable<any> {
    return this.http.get(AppSettings.packagesEndpoint)
  }

  public getServices(): Observable<ServiceModel[]> {
    return this.http.get<ServiceModel[]>(AppSettings.servicesEndpoint)
  }
}
