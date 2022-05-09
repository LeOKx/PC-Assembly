import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MaterialModule} from '../material.module';
import {MatNativeDateModule} from '@angular/material/core';
import {HttpClientModule} from '@angular/common/http';

import { SidenavResponsiveModule } from './sidenav-responsive/sidenav-responsive.module';
import { PowerPipeModule } from './pipes/power.pipe.module';
import { OwnerModule } from './owner/owner.module';
import { CpuModule } from './cpu/cpu.module';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    MatNativeDateModule,
    HttpClientModule,
    ReactiveFormsModule,
    SidenavResponsiveModule,
    PowerPipeModule,
    OwnerModule,
    CpuModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
