import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Assembly } from 'src/app/interface/pc-components/assembly/assembly.model';
import { AssemblyService } from 'src/app/shared/services/assembly.service';

@Component({
  selector: 'app-assembly-info',
  templateUrl: './assembly-info.component.html',
  styleUrls: ['./assembly-info.component.css']
})
export class AssemblyInfoComponent implements OnInit {

  public assemblyData: Assembly;
  @Input() getId: string;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private assemblyService: AssemblyService
  ) { }

  ngOnInit(): void {
    if(this.getId == null)
    {
      let objectId: string;
      this.route.params.subscribe(params =>{
        objectId = params['id'];
          this.getAssembly(objectId);
      });
    }
    else
    {
      this.getAssembly(this.getId);
    }
  }

  getAssembly(id: string): void {
    this.assemblyService.getById(id).subscribe((assemblyResponse : Assembly) => {
      this.assemblyData = assemblyResponse
    });
  }
  back(): void {
    this.location.back();
  }

}
