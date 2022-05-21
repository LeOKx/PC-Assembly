import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CpuListComponent } from '../cpu-list/cpu-list.component';
import { EditCpuComponent } from '../edit-cpu/edit-cpu.component';
import { AuthGuard } from 'src/app/shared/guards/auth.guard';
import { AdminGuard } from 'src/app/shared/guards/admin.guard';
import { CpuInfoComponent } from '../cpu-info/cpu-info.component';

const routes: Routes = [
  { path: 'cpus', component: CpuListComponent },
  { path: 'cpus/:select', component: CpuListComponent },
  { path: 'editCpu/:id', component: EditCpuComponent, canActivate: [AuthGuard, AdminGuard]},
  { path: 'infoCpu/:id', component: CpuInfoComponent},
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
