import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MaterialModule} from '../material.module';
import {MatNativeDateModule} from '@angular/material/core';
import {HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

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
import { AssemblyModule } from './assembly-components/assembly/assembly.module';
import { RozetkaModule } from './rozetka-search/rozetka/rozetka.module';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import {  NgxSlickJsModule } from 'ngx-slickjs'

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
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    MatNativeDateModule,
    HttpClientModule,
    ReactiveFormsModule,
    CpuModule,
    GraphicCardModule,
    MotherboardModule,
    PowerSupplyModule,
    RamModule,
    AssemblyModule,
    RozetkaModule,
    SlickCarouselModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        
      }
    }),
    NgxSlickJsModule.forRoot({
      links: {
        jquery: "https://code.jquery.com/jquery-3.4.0.min.js",
        slickJs: "https://cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.min.js",
        slickCss: "https://cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.css",
        slickThemeCss: "https://cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick-theme.css"
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
