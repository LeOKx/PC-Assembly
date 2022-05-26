import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MotherboardListComponent } from './motherboard-list/motherboard-list.component';
import { MaterialModule } from 'src/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ImageUploadModule } from 'src/app/image-upload/image-upload.module';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { MotherboardTableService } from 'src/app/shared/services/motherboard-table.service';
import { MotherboardInfoComponent } from './motherboard-info/motherboard-info.component';
import { EditMotherboardComponent } from './edit-motherboard/edit-motherboard.component';
import { MotherboardRoutingModule } from './motherboard-routing/motherboard-routing.module';
import { RozetkaModule } from 'src/app/rozetka-search/rozetka/rozetka.module';



@NgModule({
  declarations: [
    MotherboardListComponent,
    EditMotherboardComponent,
    MotherboardInfoComponent
  ],
  imports: [
    CommonModule,
    MotherboardRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    ImageUploadModule,
    RozetkaModule
  ],
  exports:[
    MotherboardInfoComponent
  ],
  providers: [
    MotherboardTableService,
    AuthenticationService
  ]
})
export class MotherboardModule { }
