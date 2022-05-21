
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Motherboard } from 'src/app/interface/pc-components/motherboard.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { RepositoryService } from './repository.service';

// @Injectable({
//   providedIn: 'root'
// })
@Injectable()
export class MotherboardTableService extends RepositoryService<Motherboard>{

    protected override route = "Motherboards/";
    saveMotherboard(motherboard: Motherboard): Observable<ServiceResponse<Motherboard>> {
    if (motherboard.id != '') {
      return super.update(motherboard.id, motherboard);
    }
    return super.create(motherboard);
  }
}
