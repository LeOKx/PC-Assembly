import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RamListComponent } from './ram-list/ram-list.component';
import { MaterialModule } from 'src/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ImageUploadModule } from 'src/app/image-upload/image-upload.module';
import { PowerPipeModule } from 'src/app/pipes/power.pipe.module';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { RamTableService } from 'src/app/shared/services/ram-table.service';
import { RamInfoComponent } from './ram-info/ram-info.component';
import { EditRamComponent } from './edit-ram/edit-ram.component';
import { RamRoutingModule } from './ram-routing/ram-routing.module';



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
    PowerPipeModule,
    ReactiveFormsModule,
    ImageUploadModule
  ],
  providers: [
    RamTableService,
    AuthenticationService
  ]
})
export class RamModule { }
