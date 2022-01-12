import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { AddPackageComponent } from './components/add-package/add-package.component'
import { AddUserComponent } from './components/add-user/add-user.component'
import { ChangePasswordComponent } from './components/change-password/change-password.component'
import { ChangeUserDetailsComponent } from './components/change-user-details/change-user-details.component'
import { ClientDashboardComponent } from './components/client-dashboard/client-dashboard.component'
import { PackageListComponent } from './components/package-list/package-list.component'

const routes: Routes = [
  { path: '', component: ClientDashboardComponent },
  { path: 'changePassword', component: ChangePasswordComponent },
  { path: 'addPackage', component: AddPackageComponent },
  { path: 'changeUserDetails/:id', component: ChangeUserDetailsComponent },
  { path: 'addUser', component: AddUserComponent },
  { path: 'addPackage', component: AddPackageComponent },
  { path: 'packageList', component: PackageListComponent }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientRoutingModule {}
