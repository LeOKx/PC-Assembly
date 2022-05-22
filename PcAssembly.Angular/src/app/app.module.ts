import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MaterialModule} from '../material.module';
import {MatNativeDateModule} from '@angular/material/core';
import {HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { PowerPipeModule } from './pipes/power.pipe.module';
import { ErrorHandlerService } from './shared/services/error-handler.service';
import { LayoutComponent } from './layout/layout.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './navigation/header/header.component';
import { SidenavListComponent } from './navigation/sidenav-list/sidenav-list.component';
import { JwtModule } from "@auth0/angular-jwt";
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { GraphicCardModule } from './assembly-components/graphic-card/graphic-card.module';
import { CpuModule } from './assembly-components/cpu/cpu.module';
import { MotherboardModule } from './assembly-components/motherboard/motherboard.module';
import { PowerSupplyModule } from './assembly-components/power-supply/power-supply.module';
import { RamModule } from './assembly-components/ram/ram.module';

export function tokenGetter() {
  return localStorage.getItem("token");
}


@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    HomeComponent,
    HeaderComponent,
    SidenavListComponent,
    ForbiddenComponent,
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    MatNativeDateModule,
    HttpClientModule,
    ReactiveFormsModule,
    PowerPipeModule,
    CpuModule,
    GraphicCardModule,
    MotherboardModule,
    PowerSupplyModule,
    RamModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        
      }
    })
  ],
  
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true
    }
  ],
  bootstrap: [AppComponent],
  exports: [
  ]
})
export class AppModule { }
