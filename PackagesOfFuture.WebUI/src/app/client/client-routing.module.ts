import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { MainClientComponent } from './main-client/main-client.component'

const routes: Routes = [
  { path: '', component: MainClientComponent },
  { path: 'aaa', component: MainClientComponent },
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientRoutingModule {}
