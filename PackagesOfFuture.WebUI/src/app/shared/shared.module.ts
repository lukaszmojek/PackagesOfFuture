import { NgModule } from '@angular/core'
import { LoginComponent } from './components/login/login.component'
import { MaterialModule } from './material.module'

const modules = [MaterialModule]

const components = [LoginComponent]
@NgModule({
  declarations: [...components],
  imports: [...modules],
  exports: [...modules, ...components],
})
export class SharedModule {}
