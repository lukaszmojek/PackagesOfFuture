import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { AddPackageComponent } from './add-package/add-package.component'
import { ChangePasswordComponent } from './change-password/change-password.component'
import { ClientDashboardComponent } from './client-dashboard/client-dashboard.component'

const routes: Routes = [
  { path: '', component: ClientDashboardComponent },
  { path: 'changePassword', component: ChangePasswordComponent },
  { path: 'addPackage', component: AddPackageComponent }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientRoutingModule {}
