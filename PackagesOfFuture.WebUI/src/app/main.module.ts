import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientRoutingModule } from './main-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material.module';
import { ClientDashboardComponent } from './components/client-dashboard/client-dashboard.component';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { AddPackageComponent } from './components/add-package/add-package.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';

const components = [
  ClientDashboardComponent,
  ChangePasswordComponent,
  AddPackageComponent,
  UserDetailsComponent
]

@NgModule({
  declarations: [...components],
  imports: [
    CommonModule,
    ClientRoutingModule,
    MaterialModule, 
    FormsModule, 
    ReactiveFormsModule,
  ],
  exports: [...components]
})
export class MainModule { }
