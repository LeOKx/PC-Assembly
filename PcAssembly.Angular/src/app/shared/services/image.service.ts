import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EnvironmentUrlService } from './enviroment-url.service';

@Injectable()
export class ImageService {

  constructor(private http: HttpClient, protected envUrl: EnvironmentUrlService) { }

  public uploadImage(image:File):Observable<Response>{
    const formData = new FormData();

    formData.append('image', image);
    
    return this.http.post<Response>(this.envUrl.urlAddress + '/api/images', formData);
  }
}
