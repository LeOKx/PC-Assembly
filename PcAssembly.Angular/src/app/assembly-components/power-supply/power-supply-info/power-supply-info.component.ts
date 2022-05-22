import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { Location } from '@angular/common';
import { PowerSupply } from 'src/app/interface/pc-components/power-supply.model';
import { PowerSupplyTableService } from 'src/app/shared/services/power-supply-table.service';

@Component({
  selector: 'app-power-supply-info',
  templateUrl: './power-supply-info.component.html',
  styleUrls: ['./power-supply-info.component.css']
})
export class PowerSupplyInfoComponent implements OnInit {

  public powerSupplyData: PowerSupply;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private powerSupplyService: PowerSupplyTableService
  ) { }

  ngOnInit(): void {
    let objectId: string;
    this.route.params.subscribe(params =>{
      objectId = params['id'];
        this.getPowerSupply(objectId);
    });
  }

  getPowerSupply(id: string): void {
    this.powerSupplyService.getById(id).subscribe((powerSupplyResponse : PowerSupply) => {
      this.powerSupplyData = powerSupplyResponse
    });
  }
  back(): void {
    this.location.back();
  }

}
