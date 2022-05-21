import { Component, OnInit, Output } from '@angular/core';
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

  // @Output() urlImage: EventEmitter();
  urlImage: string;
  
  selectedFile: ImageSnippet;

  constructor(private imageService: ImageService){}

  processFile(imageInput: any){
    
    const file: File = imageInput.files[0];
    const reader = new FileReader();

    reader.addEventListener('load', (event: any) => {
      debugger;
      this.selectedFile= new ImageSnippet(event.target.result, file)

      this.imageService.uploadImage(this.selectedFile.file).subscribe(
        (res) => {
          
        }
      )
    });

    reader.readAsDataURL(file);
  }

  ngOnInit(): void {
  }

}
