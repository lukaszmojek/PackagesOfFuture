import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from '../../common/appsettings';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  public changePassword(userId: number, oldPassword: string, newPassword: string): Observable<any> {
    return this.http.post(`${AppSettings.userEndpoint}/${userId}/change-password`, { userId: userId, oldPassword: oldPassword, newPassword: newPassword})
  }
}
