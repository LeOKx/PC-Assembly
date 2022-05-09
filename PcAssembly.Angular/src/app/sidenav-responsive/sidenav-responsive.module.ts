import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import {SidenavResponsive }from './sidenav-responsive.component';
import { TestComponentModule } from '../test-component/test-component.module';
import { MaterialModule } from 'src/material.module';
import { AppRoutingModule } from '../app-routing.module';



@NgModule({
  declarations: [SidenavResponsive],
  imports: [
    CommonModule,
    FormsModule,
    BrowserModule,
    TestComponentModule,
    MaterialModule,
    AppRoutingModule
  ],
  exports:[
    SidenavResponsive
  ]
})
export class SidenavResponsiveModule { }
