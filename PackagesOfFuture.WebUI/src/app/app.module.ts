import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { MenuComponent } from './components/menu/menu.component';
import { StoreModule } from '@ngrx/store'
import { AuthModule } from './auth/auth.module'
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'
import { EffectsModule } from '@ngrx/effects'
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment'
import { SharedModule } from './shared.module'
import { MainAppComponent } from './components/main-app/main-app.component'
import { LoginComponent } from './components/login/login.component';
import { PackageListComponent } from './components/package-list/package-list.component';
import { PackageDetailsModalComponent } from './components/package-details-modal/package-details-modal.component';
import { PackagePaymentModalComponent } from './components/package-payment-modal/package-payment-modal.component';


@NgModule({
  declarations: [AppComponent, MainAppComponent, MenuComponent, LoginComponent, PackageListComponent, PackageDetailsModalComponent, PackagePaymentModalComponent],
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
