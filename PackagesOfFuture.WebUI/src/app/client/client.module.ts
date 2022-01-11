import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientDashboardComponent } from './client-dashboard/client-dashboard.component';
import { ClientRoutingModule } from './client-routing.module';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { MaterialModule } from '../shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddPackageComponent } from './add-package/add-package.component';

const components = [
  ClientDashboardComponent,
  ChangePasswordComponent
]

@NgModule({
  declarations: [...components, AddPackageComponent],
  imports: [
    CommonModule,
    ClientRoutingModule,
    MaterialModule, 
    FormsModule, 
    ReactiveFormsModule,
  ],
  exports: [...components]
})
export class ClientModule { }
