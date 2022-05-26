import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/material.module';
import { AssemblyListComponent } from './assembly-list/assembly-list.component';
import { CreateAssemblyComponent } from './create-assembly/create-assembly.component';
import { AssemblyInfoComponent } from './assembly-info/assembly-info.component';
import { AssemblyRoutingModule } from './assembly-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AssemblyService } from 'src/app/shared/services/assembly.service';
import { ImageUploadModule } from 'src/app/image-upload/image-upload.module';
import { CpuModule } from '../cpu/cpu.module';
import { MotherboardModule } from '../motherboard/motherboard.module';
import { GraphicCardModule } from '../graphic-card/graphic-card.module';
import { RamModule } from '../ram/ram.module';
import { PowerSupplyModule } from '../power-supply/power-supply.module';



@NgModule({
  declarations: [
    AssemblyListComponent,
    CreateAssemblyComponent,
    AssemblyInfoComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    AssemblyRoutingModule,
    ReactiveFormsModule,
    ImageUploadModule,
    CpuModule,
    MotherboardModule,
    GraphicCardModule,
    RamModule,
    PowerSupplyModule
  ],
  providers: [
    AssemblyService
  ]
})
export class AssemblyModule { }
