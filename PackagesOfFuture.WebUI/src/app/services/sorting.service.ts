import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { CourierType } from 'src/app/models/couriers';
import { AppSettings } from '../common/appsettings';
import { ChangeStatusPaymentDto, PackageDto, RegisterPackageDto } from '../models/packages';
import { AddSortingDto, ChangeSortingDetailsDto, SortingDto } from '../models/sorting';
import { SnackbarService } from './snackbar.service';

@Injectable({
  providedIn: 'root'
})
export class SortingService {

  constructor(private http: HttpClient, private snackbar: SnackbarService) { }

  public getSorting(): Observable<SortingDto[]> {
    return this.http.get<SortingDto[]>(AppSettings.sortingEndpoint)
  }

  public addSorting(request: AddSortingDto): Observable<any> {
    return this.http.post(AppSettings.sortingEndpoint, request).pipe(tap(_ => {
      this.snackbar.displaySnackbar('Sortowania dodana pomyślnie')
    }))
  }

  public changeSortingDetails(request: ChangeSortingDetailsDto): Observable<any> {
    return this.http.post(`${AppSettings.sortingEndpoint}/${request.id}/change-details`, request).pipe(tap(_ => {
      this.snackbar.displaySnackbar('Edycja sortowni przebiegła pomyślnie')
    }))
  }
}
