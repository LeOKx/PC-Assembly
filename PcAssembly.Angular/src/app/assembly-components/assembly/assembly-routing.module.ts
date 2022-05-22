import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AssemblyListComponent } from './assembly-list/assembly-list.component';
import { CreateAssemblyComponent } from './create-assembly/create-assembly.component';
import { AssemblyInfoComponent } from './assembly-info/assembly-info.component';

const routes: Routes = [
  { path: 'assemblies', component: AssemblyListComponent },
  { path: 'create-assembly', component: CreateAssemblyComponent },
  // { path: 'assembly-edit/:id', component: EditCpuComponent, canActivate: [AuthGuard, AdminGuard]},
  { path: 'assembly-info/:id', component: AssemblyInfoComponent},
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
export class AssemblyRoutingModule { }
