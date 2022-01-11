import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { AuthGuard } from './auth/auth.guard'
import { LoginComponent } from './components/login/login.component'

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
    //TODO: Create LoginGuard
    // canActivate: LoginGuard
  },
  {
    path: '',
    canLoad: [AuthGuard],
    loadChildren: () => import('./main.module').then(m => m.MainModule)
  },
  {
    path: '**',
    redirectTo: 'login'
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
