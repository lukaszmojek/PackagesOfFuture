import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { LoginComponent } from './shared/components/login/login.component'

const routes: Routes = [
  {
    path: '',
    component: LoginComponent,
    //TODO: Create LoginGuard
    // canActivate: LoginGuard
  },
  {
    path: 'client', 
    loadChildren: () => import('./client/client.module').then(m => m.ClientModule)
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
