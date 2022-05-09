import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './test-component/test-component.component';

const routes: Routes = [
  { path: '', redirectTo: '/test', pathMatch: 'full' },
  { 
    path: 'test', 
    component: TestComponent 
  },
  { path: 'cpu', loadChildren: () => import('./cpu/cpu.module').then(m => m.CpuModule) }, 
  { path: 'owner', loadChildren: () => import('./owner/owner.module').then(m => m.OwnerModule) },
  // { 
  //   path: 'test', 
  //   loadChildren: () => import('./test-component/test-component.module').then(m => m.TestComponentModule)
  // },
  // { 
  //   path: 'cpus', 
  //   loadChildren: () => import('./cpu-table/cpu-table.module').then(m => m.CpuTableModule)
  // },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
