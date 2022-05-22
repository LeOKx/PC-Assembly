
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PowerSupply } from 'src/app/interface/pc-components/power-supply.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { RepositoryService } from './repository.service';

@Injectable()
export class PowerSupplyTableService extends RepositoryService<PowerSupply>{

    protected override route = "PowerSupplies/";
    savePowerSupply(powerSupply: PowerSupply): Observable<ServiceResponse<PowerSupply>> {
    if (powerSupply.id != '') {
      return super.update(powerSupply.id, powerSupply);
    }
    return super.create(powerSupply);
  }
}
