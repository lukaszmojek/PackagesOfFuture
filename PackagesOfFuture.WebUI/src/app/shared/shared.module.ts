import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { LoginComponent } from './components/login/login.component'
import { MaterialModule } from './material.module'

const modules = [
  CommonModule,
  MaterialModule, 
  FormsModule, 
  ReactiveFormsModule,
]

const components = [LoginComponent]
@NgModule({
  declarations: [...components],
  imports: [...modules],
  exports: [...modules, ...components],
})
export class SharedModule {}
