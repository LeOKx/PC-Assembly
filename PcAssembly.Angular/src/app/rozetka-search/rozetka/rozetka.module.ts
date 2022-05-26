import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RozetkaComponent } from './rozetka.component';
import { MaterialModule } from 'src/material.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    RozetkaComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    RozetkaComponent
  ]
})
export class RozetkaModule { }
