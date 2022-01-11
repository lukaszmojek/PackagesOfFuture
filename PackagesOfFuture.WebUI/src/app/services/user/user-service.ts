import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChangePasswordDto } from 'src/app/models/users';
import { AppSettings } from '../../common/appsettings';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  public changePassword(userId: number, oldPassword: string, newPassword: string): Observable<any> {
    const url = `${AppSettings.userEndpoint}/${userId}/change-password`
    
    const data: ChangePasswordDto = { 
      userId, 
      oldPassword, 
      newPassword
    }

    return this.http.post(url, data)
  }
}
