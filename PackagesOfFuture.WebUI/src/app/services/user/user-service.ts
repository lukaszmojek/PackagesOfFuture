import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Address } from 'src/app/models/addresses';
import { ChangePasswordDto, RegisterUserDto, User } from 'src/app/models/users';
import { AppSettings } from '../../common/appsettings';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  //TODO: implement this
  public getUserById(id: number): Observable<User> {
    return of({
      id: id,
      firstName: 'firstName',        
      lastName: 'lastName',
      email: 'email',
      type: 'type',
      password: 'password',
      address: {
        street: 'street',
        houseAndFlatNumber: 'houseAndFlatNumber',
        city: 'city',
        postalCode: 'postalCode',
      } as Address
    } as User)
  }

  public getAllUsers(): Observable<User[]> {
    const url = `${AppSettings.userEndpoint}`

    return this.http.get<User[]>(url)
  }

  //TODO: test this
  public registerUser(registerUserDto: RegisterUserDto): Observable<any> {
    const url = `${AppSettings.userEndpoint}`

    return this.http.post(url, registerUserDto)
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
}
