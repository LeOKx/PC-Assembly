import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CPU } from 'src/app/interface/pc-components/cpu.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { CpuTableService } from 'src/app/shared/services/cpu-table.service';

@Component({
  selector: 'app-edit-cpu',
  templateUrl: './edit-cpu.component.html',
  styleUrls: ['./edit-cpu.component.css']
})
export class EditCpuComponent implements OnInit{


  public pageTitle: string;
  public cpuForm: FormGroup;

  cpuResp: ServiceResponse<CPU>;
  cpu: CPU;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private cpuService: CpuTableService
  ) { }

  ngOnInit(): void {
    let objectId: string;
    this.route.params.subscribe(params =>{
      objectId = params['id'];
      if(objectId === ''){
        this.pageTitle = 'Add Cpu: ';
      }else {
        this.getCpu(objectId);
        this.pageTitle = 'Edit Cpu: ';
      }
    });

    this.cpuForm = this.formBuilder.group({
      id: [objectId],
      type: 'CPU',
      model: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
      company: ['', [Validators.required, Validators.minLength(3)]],
      price: ['', [Validators.required]],
      socket: ['', [Validators.required]],
      powerConsumption: ['', [Validators.required]],
      family: ['', [Validators.required]],
      generation: ['', [Validators.required]],
      cores: ['', [Validators.required]],
      threads: ['', [Validators.required]],
      frequency: ['', [Validators.required]],
      imageUrl: null,
      infoAbout: [''],
      
    });
  }
  // cpuResponse: ServiceResponse<CPU>;
  cpuObj: CPU;


  getCpu(id: string): void {
    this.cpuService.getById(id).subscribe((cpuResponse : CPU) => {
      this.cpuForm.patchValue({
        ...cpuResponse
      });
    });
  }


  public hasError = (controlName: string, errorName: string) => {
    return this.cpuForm.controls[controlName].hasError(errorName)
  }
  saveCpu(): void {
    if (this.cpuForm.dirty && this.cpuForm.valid) {
       const cpuToSave: CPU = {
         ...this.cpuForm.value
       };
       if(cpuToSave.infoAbout == null){
         cpuToSave.infoAbout = '';
       }
       if(cpuToSave.imageUrl == ''){
        cpuToSave.imageUrl = 'https://st.depositphotos.com/32466374/53062/v/600/depositphotos_530621888-stock-illustration-cpu-icon-chip-in-line.jpg';
      }
       this.cpuService.saveCpu(cpuToSave).subscribe(
         () => this.onSaveComplete()
       );
    }
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.cpuForm.reset();
    this.router.navigate(['/cpus','']);
  }

  
}
