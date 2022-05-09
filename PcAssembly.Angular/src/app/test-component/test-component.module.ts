import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestComponent } from './test-component.component';
import { MaterialModule } from 'src/material.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { TestArrayModule } from '../test-array/test-array.module';
import { DatePickerModule } from '../date-picker/date-picker.module';
import { TestTablePaginatorModule } from '../test-table-paginator/test-table-paginator.module';



@NgModule({
  declarations: [
    TestComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    BrowserModule,
    MaterialModule,
    TestArrayModule,
    DatePickerModule,
    TestTablePaginatorModule
  ],

  exports:[
    TestComponent
  ]
})
export class TestComponentModule { }
