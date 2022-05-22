import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { RamListComponent } from '../ram-list/ram-list.component';
import { EditRamComponent } from '../edit-ram/edit-ram.component';
import { AuthGuard } from 'src/app/shared/guards/auth.guard';
import { AdminGuard } from 'src/app/shared/guards/admin.guard';
import { RamInfoComponent } from '../ram-info/ram-info.component';

const routes: Routes = [
  { path: 'rams', component: RamListComponent },
  { path: 'rams/:select', component: RamListComponent },
  { path: 'editRam/:id', component: EditRamComponent, canActivate: [AuthGuard, AdminGuard]},
  { path: 'infoRam/:id', component: RamInfoComponent},
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
export class RamRoutingModule { }
