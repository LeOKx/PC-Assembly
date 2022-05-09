import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DatePickerComponent } from './date-picker.component';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MaterialModule } from 'src/material.module';
import { TestComponentModule } from '../test-component/test-component.module';



@NgModule({
  declarations: [
    DatePickerComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    BrowserModule,
    MaterialModule
  ],
  exports: [
    DatePickerComponent
  ]
})
export class DatePickerModule { }
