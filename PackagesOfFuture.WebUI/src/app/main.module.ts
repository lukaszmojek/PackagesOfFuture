import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainRoutingModule } from './main-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { AddPackageComponent } from './components/add-package/add-package.component';
import { UsersListComponent } from './components/users-list/users-list.component';

const components = [
  DashboardComponent,
  ChangePasswordComponent,
  AddPackageComponent,
  UsersListComponent
]

@NgModule({
  declarations: [...components],
  imports: [
    CommonModule,
    MainRoutingModule,
    MaterialModule, 
    FormsModule, 
    ReactiveFormsModule,
  ],
  exports: [...components]
})
export class MainModule { }
