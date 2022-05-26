import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RamListComponent } from './ram-list/ram-list.component';
import { MaterialModule } from 'src/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ImageUploadModule } from 'src/app/image-upload/image-upload.module';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { RamTableService } from 'src/app/shared/services/ram-table.service';
import { RamInfoComponent } from './ram-info/ram-info.component';
import { EditRamComponent } from './edit-ram/edit-ram.component';
import { RamRoutingModule } from './ram-routing/ram-routing.module';
import { RozetkaModule } from 'src/app/rozetka-search/rozetka/rozetka.module';



@NgModule({
  declarations: [
    RamListComponent,
    EditRamComponent,
    RamInfoComponent
  ],
  imports: [
    CommonModule,
    RamRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    ImageUploadModule,
    RozetkaModule
  ],
  exports:[
    RamInfoComponent
  ],
  providers: [
    RamTableService,
    AuthenticationService
  ]
})
export class RamModule { }
