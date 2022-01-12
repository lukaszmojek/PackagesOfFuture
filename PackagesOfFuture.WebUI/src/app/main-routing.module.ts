import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { AddPackageComponent } from './components/add-package/add-package.component'
import { ChangePasswordComponent } from './components/change-password/change-password.component'
import { ClientDashboardComponent } from './components/client-dashboard/client-dashboard.component'
import { PackageListComponent } from './components/package-list/package-list.component'

const routes: Routes = [
  { path: '', component: ClientDashboardComponent },
  { path: 'changePassword', component: ChangePasswordComponent },
  { path: 'addPackage', component: AddPackageComponent },
  { path: 'packageList', component: PackageListComponent }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientRoutingModule {}
