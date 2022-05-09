import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestArrayComponent } from './test-array.component';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MaterialModule } from 'src/material.module';



@NgModule({
  declarations: [
    TestArrayComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    BrowserModule,
    MaterialModule,
  ],
  exports: [
    TestArrayComponent
  ]
})
export class TestArrayModule { }
