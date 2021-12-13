import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainClientComponent } from './main-client/main-client.component';
import { ClientRoutingModule } from './client-routing.module';

const components = [
  MainClientComponent
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
