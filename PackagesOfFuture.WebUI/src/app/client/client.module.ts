import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientDashboardComponent } from './client-dashboard/client-dashboard.component';
import { ClientRoutingModule } from './client-routing.module';

const components = [
  ClientDashboardComponent
]

@NgModule({
  declarations: [...components],
  imports: [
    CommonModule,
    ClientRoutingModule
  ],
  exports: [...components]
})
export class ClientModule { }
