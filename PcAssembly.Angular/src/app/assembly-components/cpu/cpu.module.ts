import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CpuListComponent } from './cpu-list/cpu-list.component';
import { CpuRoutingModule } from './cpu-routing/cpu-routing.module';
import { MaterialModule } from 'src/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { EditCpuComponent } from './edit-cpu/edit-cpu.component';
import { CpuInfoComponent } from './cpu-info/cpu-info.component';
import { ImageUploadModule } from 'src/app/image-upload/image-upload.module';
import { PowerPipeModule } from 'src/app/pipes/power.pipe.module';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { CpuTableService } from 'src/app/shared/services/cpu-table.service';



@NgModule({
  declarations: [
    CpuListComponent,
    EditCpuComponent,
    CpuInfoComponent
  ],
  imports: [
    CommonModule,
    CpuRoutingModule,
    MaterialModule,
    PowerPipeModule,
    ReactiveFormsModule,
    ImageUploadModule
  ],
  providers: [
    CpuTableService,
    AuthenticationService
  ]
})
export class CpuModule { }
