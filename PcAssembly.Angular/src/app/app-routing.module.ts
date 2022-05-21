import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { AdminGuard } from './shared/guards/admin.guard';
import { AuthGuard } from './shared/guards/auth.guard';

const routes: Routes = [
  { path: 'home', component: HomeComponent},
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
  { path: 'forbidden', component: ForbiddenComponent },
  // { path: 'cpu', loadChildren: () => import('./assembly-components/cpu/cpu.module').then(m => m.CpuModule) }, 
  // { path: 'graphic-card', loadChildren: () => import('./assembly-components/graphic-card/graphic-card.module').then(m => m.GraphicCardModule) },

];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
