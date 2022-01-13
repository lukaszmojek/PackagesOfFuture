import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from '../common/appsettings';
import { ChangeSortingDroneDto, DroneDto, EditDroneDto, RegisterDroneDto } from '../models/drone';
import { SortingDto } from '../models/sorting';

@Injectable({
  providedIn: 'root'
})
export class DroneService {

  constructor(private http: HttpClient) { }

  public getDrones(): Observable<DroneDto[]> {
    return this.http.get<DroneDto[]>(AppSettings.dronesEndpoint)
  }

  public removeDrone(droneId: number): Observable<any> {
    return this.http.delete(`${AppSettings.dronesEndpoint}/${droneId}/unregister`);
  }

  public registerDrone(registerDroneDto: RegisterDroneDto): Observable<any> {
    return this.http.post(`${AppSettings.dronesEndpoint}`, registerDroneDto);
  }

  public editDrone(request: EditDroneDto): Observable<any> {
    return this.http.post(`${AppSettings.dronesEndpoint}/${request.droneId}/move-to-sorting`, request)
  }




}
