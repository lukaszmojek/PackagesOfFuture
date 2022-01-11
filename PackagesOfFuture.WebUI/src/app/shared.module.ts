import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { MaterialModule } from './material.module'

const modules = [
  CommonModule,
  MaterialModule, 
  FormsModule, 
  ReactiveFormsModule,
]

@NgModule({
  imports: [...modules],
  exports: [...modules],
})
export class SharedModule {}
