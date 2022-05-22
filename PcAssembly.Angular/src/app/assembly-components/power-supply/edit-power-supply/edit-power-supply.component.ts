import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PowerSupply } from 'src/app/interface/pc-components/power-supply.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { PowerSupplyTableService } from 'src/app/shared/services/power-supply-table.service';

@Component({
  selector: 'app-edit-powerSupply',
  templateUrl: './edit-power-supply.component.html',
  styleUrls: ['./edit-power-supply.component.css']
})
export class EditPowerSupplyComponent implements OnInit{


  public pageTitle: string;
  public powerSupplyForm: FormGroup;

  powerSupplyResp: ServiceResponse<PowerSupply>;
  powerSupply: PowerSupply;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private powerSupplyService: PowerSupplyTableService
  ) { }

  ngOnInit(): void {
    let objectId: string;
    this.route.params.subscribe(params =>{
      objectId = params['id'];
      if(objectId === ''){
        this.pageTitle = 'Add PowerSupply: ';
      }else {
        this.getPowerSupply(objectId);
        this.pageTitle = 'Edit PowerSupply: ';
      }
    });

    this.powerSupplyForm = this.formBuilder.group({
      id: [objectId],
      type: 'PowerSupply',
      model: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
      company: ['', [Validators.required, Validators.minLength(3)]],
      price: ['', [Validators.required]],
      powerConsumption: ['', [Validators.required]],
      power: ['', [Validators.required]],
      imageUrl: null,
      infoAbout: ['', Validators.maxLength(500)],
      
    });
  }
  // powerSupplyResponse: ServiceResponse<PowerSupply>;
  powerSupplyObj: PowerSupply;


  getPowerSupply(id: string): void {
    this.powerSupplyService.getById(id).subscribe((powerSupplyResponse : PowerSupply) => {
      this.powerSupplyForm.patchValue({
        ...powerSupplyResponse
      });
    });
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.powerSupplyForm.controls[controlName].hasError(errorName)
  }
  savePowerSupply(): void {
    if (this.powerSupplyForm.dirty && this.powerSupplyForm.valid) {
       const powerSupplyToSave: PowerSupply = {
         ...this.powerSupplyForm.value
       };
       if(powerSupplyToSave.infoAbout == null){
         powerSupplyToSave.infoAbout = '';
       }
       if(powerSupplyToSave.imageUrl == ''){
        powerSupplyToSave.imageUrl = 'https://icon-library.com/images/icon-power-supply/icon-power-supply-9.jpg';
      }
       this.powerSupplyService.savePowerSupply(powerSupplyToSave).subscribe(
         () => this.onSaveComplete()
       );
    }
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.powerSupplyForm.reset();
    this.router.navigate(['/power-supplys','']);
  }

  
}
