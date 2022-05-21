import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { Location } from '@angular/common';
import { Motherboard } from 'src/app/interface/pc-components/motherboard.model';
import { MotherboardTableService } from 'src/app/shared/services/motherboard-table.service';
import { PowerSupply } from 'src/app/interface/pc-components/power-supply.model';

@Component({
  selector: 'app-motherboard-info',
  templateUrl: './motherboard-info.component.html',
  styleUrls: ['./motherboard-info.component.css']
})
export class MotherboardInfoComponent implements OnInit {

  public motherboardData: Motherboard;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private motherboardService: MotherboardTableService
  ) { }

  ngOnInit(): void {
    let objectId: string;
    this.route.params.subscribe(params =>{
      objectId = params['id'];
        this.getMotherboard(objectId);
    });
  }

  getMotherboard(id: string): void {
    this.motherboardService.getById(id).subscribe((motherboardResponse : Motherboard) => {
      this.motherboardData = motherboardResponse
    });
  }
  back(): void {
    this.location.back();
  }

}
