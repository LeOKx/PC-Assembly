import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ImageUploadComponent } from './image-upload.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ImageService } from '../shared/services/image.service';
import { MaterialModule } from 'src/material.module';




@NgModule({
  declarations: [
    ImageUploadComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    MaterialModule
  ],
  providers: [
    ImageService
  ],
  exports: [
    ImageUploadComponent
  ]
})
export class ImageUploadModule { }
