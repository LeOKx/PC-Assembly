import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { Location } from '@angular/common';
import { Ram } from 'src/app/interface/pc-components/ram.model';
import { RamTableService } from 'src/app/shared/services/ram-table.service';

@Component({
  selector: 'app-ram-info',
  templateUrl: './ram-info.component.html',
  styleUrls: ['./ram-info.component.css']
})
export class RamInfoComponent implements OnInit {

  public ramData: Ram;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private ramService: RamTableService
  ) { }

  ngOnInit(): void {
    let objectId: string;
    this.route.params.subscribe(params =>{
      objectId = params['id'];
        this.getRam(objectId);
    });
  }

  getRam(id: string): void {
    this.ramService.getById(id).subscribe((ramResponse : Ram) => {
      this.ramData = ramResponse
    });
  }
  back(): void {
    this.location.back();
  }

}
