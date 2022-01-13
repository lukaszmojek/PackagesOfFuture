import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IApiResponse } from 'src/app/auth/models';
import { ChangePasswordDto, ChangeUserDetailsDto, RegisterUserDto, User } from 'src/app/models/users';
import { AppSettings } from '../common/appsettings';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  public getUserById(userId: number): Observable<User> {
    const url = `${AppSettings.userEndpoint}/getByUserId/${userId}`

    return this.http.get<User>(url)
  }

  public getAllUsers(): Observable<User[]> {
    const url = `${AppSettings.userEndpoint}`

    return this.http.get<User[]>(url)
  }

  public registerUser(registerUserDto: RegisterUserDto): Observable<any> {
    const url = `${AppSettings.userEndpoint}`

    return this.http.post(url, registerUserDto)
  }

  public changeUserDetails(changeUserDetailsDto: ChangeUserDetailsDto): Observable<any> {
    const url = `${AppSettings.userEndpoint}/${changeUserDetailsDto.id}/change-details`

    return this.http.post(url, changeUserDetailsDto)
  }

  public changePassword(userId: number, oldPassword: string, newPassword: string): Observable<any> {
    const url = `${AppSettings.userEndpoint}/${userId}/change-password`
    
    const data: ChangePasswordDto = { 
      userId, 
      oldPassword, 
      newPassword
    }

    return this.http.post(url, data)
  }

  public unregisterUser(userId: number): Observable<IApiResponse<any>> {
    const url = `${AppSettings.userEndpoint}/${userId}/unregister`

    return this.http.delete<IApiResponse<any>>(url)
  }
}
