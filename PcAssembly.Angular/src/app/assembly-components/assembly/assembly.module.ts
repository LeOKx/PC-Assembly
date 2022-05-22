import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/material.module';
import { AssemblyListComponent } from './assembly-list/assembly-list.component';
import { CreateAssemblyComponent } from './create-assembly/create-assembly.component';
import { AssemblyInfoComponent } from './assembly-info/assembly-info.component';
import { AssemblyRoutingModule } from './assembly-routing.module';



@NgModule({
  declarations: [
    AssemblyListComponent,
    CreateAssemblyComponent,
    AssemblyInfoComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    AssemblyRoutingModule
  ]
})
export class AssemblyModule { }
