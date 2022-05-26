import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ImageUrl } from 'src/app/interface/imageUrl';
import { EnvironmentUrlService } from './enviroment-url.service';

@Injectable()
export class ImageService {

  constructor(private http: HttpClient, protected envUrl: EnvironmentUrlService) { }

  public uploadImage(image:File):Observable<ImageUrl>{
    const formData = new FormData();

    formData.append('image', image);
    
    return this.http.post<ImageUrl>(this.envUrl.urlAddress + '/images', formData)
  }
}
