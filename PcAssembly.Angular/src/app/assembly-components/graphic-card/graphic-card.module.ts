import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GraphicCardListComponent } from './graphic-card-list/graphic-card-list.component';
import { MaterialModule } from 'src/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ImageUploadModule } from 'src/app/image-upload/image-upload.module';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { GraphicCardTableService } from 'src/app/shared/services/graphic-card-table.service';
import { GraphicCardInfoComponent } from './graphic-card-info/graphic-card-info.component';
import { EditGraphicCardComponent } from './edit-graphic-card/edit-graphic-card.component';
import { GraphicCardRoutingModule } from './graphic-card-routing/graphic-card-routing.module';
import { RozetkaModule } from 'src/app/rozetka-search/rozetka/rozetka.module';



@NgModule({
  declarations: [
    GraphicCardListComponent,
    EditGraphicCardComponent,
    GraphicCardInfoComponent
  ],
  imports: [
    CommonModule,
    GraphicCardRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    ImageUploadModule,
    RozetkaModule
  ],
  exports: [
    GraphicCardInfoComponent
  ],
  providers: [
    GraphicCardTableService,
    AuthenticationService
  ]
})
export class GraphicCardModule { }
