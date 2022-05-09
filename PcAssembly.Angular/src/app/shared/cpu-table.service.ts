import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
@Injectable()
export class CpuTableService {

  constructor(private http: HttpClient) { }

  public CPUs(){
    console.log(this.http.get("https://localhost:7144/api/Cpus"));
   return this.http.get("https://localhost:7144/api/Cpus");
    
  }
}
