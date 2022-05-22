import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PowerSupplyListComponent } from '../power-supply-list/power-supply-list.component';
import { EditPowerSupplyComponent } from '../edit-power-supply/edit-power-supply.component';
import { AuthGuard } from 'src/app/shared/guards/auth.guard';
import { AdminGuard } from 'src/app/shared/guards/admin.guard';
import { PowerSupplyInfoComponent } from '../power-supply-info/power-supply-info.component';

const routes: Routes = [
  { path: 'power-supplies', component: PowerSupplyListComponent },
  { path: 'power-supplies/:select', component: PowerSupplyListComponent },
  { path: 'editPowerSupply/:id', component: EditPowerSupplyComponent, canActivate: [AuthGuard, AdminGuard]},
  { path: 'infoPowerSupply/:id', component: PowerSupplyInfoComponent},
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
export class PowerSupplyRoutingModule { }
