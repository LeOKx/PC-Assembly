import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MotherboardListComponent } from '../motherboard-list/motherboard-list.component';
import { EditMotherboardComponent } from '../edit-motherboard/edit-motherboard.component';
import { AuthGuard } from 'src/app/shared/guards/auth.guard';
import { AdminGuard } from 'src/app/shared/guards/admin.guard';
import { MotherboardInfoComponent } from '../motherboard-info/motherboard-info.component';

const routes: Routes = [
  { path: 'motherboards', component: MotherboardListComponent },
  { path: 'motherboards/:select', component: MotherboardListComponent },
  { path: 'editMotherboard/:id', component: EditMotherboardComponent, canActivate: [AuthGuard, AdminGuard]},
  { path: 'infoMotherboard/:id', component: MotherboardInfoComponent},
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
export class MotherboardRoutingModule { }
