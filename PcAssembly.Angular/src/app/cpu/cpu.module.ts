import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CpuListComponent } from './cpu-list/cpu-list.component';
import { CpuRoutingModule } from './cpu-routing/cpu-routing.module';
import { MaterialModule } from 'src/material.module';



@NgModule({
  declarations: [
    CpuListComponent
  ],
  imports: [
    CommonModule,
    CpuRoutingModule,
    MaterialModule
  ]
})
export class CpuModule { }
