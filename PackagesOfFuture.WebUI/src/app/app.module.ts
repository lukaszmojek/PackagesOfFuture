import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { MenuComponent } from './components/menu/menu.component'
import { StoreModule } from '@ngrx/store'
import { AuthModule } from './auth/auth.module'
import { CommonModule } from '@angular/common'
import { HttpClientModule } from '@angular/common/http'
import { EffectsModule } from '@ngrx/effects'
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment'
import { SharedModule } from './shared.module'
import { MainAppComponent } from './components/main-app/main-app.component'
import { LoginComponent } from './components/login/login.component'
import { PackageListComponent } from './components/package-list/package-list.component'
import { PackageDetailsModalComponent } from './components/package-details-modal/package-details-modal.component'
import { UserDetailsComponent } from './components/user-details/user-details.component'
import { RegisterUserComponent } from './components/register-user/register-user.component'
import { AddUserComponent } from './components/add-user/add-user.component'
import { ChangeUserDetailsComponent } from './components/change-user-details/change-user-details.component'
import { PackagePaymentModalComponent } from './components/package-payment-modal/package-payment-modal.component'
import { LoggedUserComponent } from './components/logged-user/logged-user.component';
import { ManageSortingComponent } from './components/manage-sorting/manage-sorting.component';
import { RemoveObjectModalComponent } from './components/remove-object-modal/remove-object-modal.component';
import { ManageDronesComponent } from './components/manage-drones/manage-drones.component';
import { AddDroneModalComponent } from './components/add-drone-modal/add-drone-modal.component';
import { SortingModalComponent } from './components/sorting-modal/sorting-modal.component';
import { ChangePackageStatusModalComponent } from './components/change-package-status-modal/change-package-status-modal.component'

const components = [
  AppComponent, 
  MainAppComponent, 
  MenuComponent, 
  LoginComponent,
  UserDetailsComponent, 
  RegisterUserComponent,
  AddUserComponent,
  ChangeUserDetailsComponent,
  PackageListComponent,
  PackageDetailsModalComponent,
  PackagePaymentModalComponent,
  LoggedUserComponent
]
@NgModule({
  declarations: [...components, ManageSortingComponent, RemoveObjectModalComponent, ManageDronesComponent, AddDroneModalComponent, SortingModalComponent, ChangePackageStatusModalComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    StoreModule.forRoot({}, {}),
    EffectsModule.forRoot([]),
    AuthModule,
    CommonModule,
    SharedModule,
    HttpClientModule,
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: environment.production })
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
