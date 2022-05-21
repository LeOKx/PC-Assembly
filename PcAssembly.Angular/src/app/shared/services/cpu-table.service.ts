import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CPU } from 'src/app/interface/pc-components/cpu.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { RepositoryService } from './repository.service';

// @Injectable({
//   providedIn: 'root'
// })
@Injectable()
export class CpuTableService extends RepositoryService<CPU>{

    protected override route = "Cpus/";
    saveCpu(cpu: CPU): Observable<ServiceResponse<CPU>> {
    if (cpu.id != '') {
      return super.update(cpu.id, cpu);
    }
    return super.create(cpu);
  }
}
