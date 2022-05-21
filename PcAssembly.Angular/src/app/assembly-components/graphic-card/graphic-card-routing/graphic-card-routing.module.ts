import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { GraphicCardListComponent } from '../graphic-card-list/graphic-card-list.component';
import { EditGraphicCardComponent } from '../edit-graphic-card/edit-graphic-card.component';
import { AuthGuard } from 'src/app/shared/guards/auth.guard';
import { AdminGuard } from 'src/app/shared/guards/admin.guard';
import { GraphicCardInfoComponent } from '../graphic-card-info/graphic-card-info.component';

const routes: Routes = [
  { path: 'graphic-cards', component: GraphicCardListComponent },
  { path: 'graphic-cards/:select', component: GraphicCardListComponent },
  { path: 'editGraphicCard/:id', component: EditGraphicCardComponent, canActivate: [AuthGuard, AdminGuard]},
  { path: 'infoGraphicCard/:id', component: GraphicCardInfoComponent},
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
export class GraphicCardRoutingModule { }
