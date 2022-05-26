import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ImageUrl } from '../interface/imageUrl';
import { ImageService } from '../shared/services/image.service';

class ImageSnippet {
  constructor(public src: string, public file: File){}
}

@Component({
  selector: 'app-image-upload',
  templateUrl: './image-upload.component.html',
  styleUrls: ['./image-upload.component.css']
})
export class ImageUploadComponent implements OnInit {

  @Output() urlImageUpload = new EventEmitter<string>();
  
  selectedFile: ImageSnippet;

  constructor(private imageService: ImageService){}

  processFile(imageInput: any){
    
    const file: File = imageInput.files[0];
    const reader = new FileReader();

    reader.addEventListener('load', (event: any) => {
      
      this.selectedFile= new ImageSnippet(event.target.result, file)
      
       this.imageService.uploadImage(this.selectedFile.file)
      .subscribe((url:ImageUrl) => {
        this.urlImageUpload.emit(url.imageUrl);
      });
      
    });

    reader.readAsDataURL(file);
  }

  ngOnInit(): void {
  }

}
