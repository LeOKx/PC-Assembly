
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ram } from 'src/app/interface/pc-components/ram.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { RepositoryService } from './repository.service';

// @Injectable({
//   providedIn: 'root'
// })
@Injectable()
export class RamTableService extends RepositoryService<Ram>{

    protected override route = "Rams/";
    saveRam(ram: Ram): Observable<ServiceResponse<Ram>> {
    if (ram.id != '') {
      return super.update(ram.id, ram);
    }
    return super.create(ram);
  }
}
