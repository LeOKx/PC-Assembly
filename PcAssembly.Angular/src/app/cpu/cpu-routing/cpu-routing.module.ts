import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CpuListComponent } from '../cpu-list/cpu-list.component';

const routes: Routes = [
  { path: 'cpus', component: CpuListComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule
  ],
})
export class CpuRoutingModule { }
