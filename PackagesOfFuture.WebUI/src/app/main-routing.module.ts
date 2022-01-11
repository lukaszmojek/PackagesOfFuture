import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { AddPackageComponent } from './components/add-package/add-package.component'
import { ChangePasswordComponent } from './components/change-password/change-password.component'
import { ClientDashboardComponent } from './components/client-dashboard/client-dashboard.component'
import { UserDetailsComponent } from './components/user-details/user-details.component'

const routes: Routes = [
  { path: '', component: ClientDashboardComponent },
  { path: 'changePassword', component: ChangePasswordComponent },
  { path: 'addPackage', component: AddPackageComponent },
  { path: 'register', component: UserDetailsComponent },
  { path: 'user/:id', component: UserDetailsComponent },
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientRoutingModule {}
