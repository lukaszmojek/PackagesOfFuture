import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CourierType } from 'src/app/models/couriers';
import { AppSettings } from '../common/appsettings';
import { ChangeStatusPaymentDto, PackageDto, RegisterPackageDto } from '../models/packages';
import { AddSortingDto, ChangeSortingDetailsDto, SortingDto } from '../models/sorting';

@Injectable({
  providedIn: 'root'
})
export class SortingService {

  constructor(private http: HttpClient) { }

  public getSorting(): Observable<SortingDto[]> {
    return this.http.get<SortingDto[]>(AppSettings.sortingEndpoint)
  }

  public addSorting(request: AddSortingDto): Observable<any> {
    return this.http.post(AppSettings.sortingEndpoint, request);
  }

  public changeSortingDetails(request: ChangeSortingDetailsDto): Observable<any> {
    return this.http.post(`${AppSettings.sortingEndpoint}/${request.id}/change-details`, request)
  }
}
