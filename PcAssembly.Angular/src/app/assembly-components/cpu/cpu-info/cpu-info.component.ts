import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { Location } from '@angular/common';
import { CPU } from 'src/app/interface/pc-components/cpu.model';
import { CpuTableService } from 'src/app/shared/services/cpu-table.service';

@Component({
  selector: 'app-cpu-info',
  templateUrl: './cpu-info.component.html',
  styleUrls: ['./cpu-info.component.css']
})
export class CpuInfoComponent implements OnInit {

  public cpuData: CPU;
  @Input() getId?: string;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private cpuService: CpuTableService
  ) { }

  ngOnInit(): void {
    if(this.getId == null)
    {
      let objectId: string;
      this.route.params.subscribe(params =>{
        objectId = params['id'];
          this.getCpu(objectId);
      });
    }
    else
    {
      this.getCpu(this.getId);
    }
    
  }

  getCpu(id: string): void {
    this.cpuService.getById(id).subscribe((cpuResponse : CPU) => {
      this.cpuData = cpuResponse
    });
  }
  back(): void {
    this.location.back();
  }

}
