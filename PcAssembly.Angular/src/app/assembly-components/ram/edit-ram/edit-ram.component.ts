import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Ram } from 'src/app/interface/pc-components/ram.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { RamTableService } from 'src/app/shared/services/ram-table.service';

@Component({
  selector: 'app-edit-ram',
  templateUrl: './edit-ram.component.html',
  styleUrls: ['./edit-ram.component.css']
})
export class EditRamComponent implements OnInit{


  public pageTitle: string;
  public ramForm: FormGroup;

  ramResp: ServiceResponse<Ram>;
  ram: Ram;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private ramService: RamTableService
  ) { }

  ngOnInit(): void {
    let objectId: string;
    this.route.params.subscribe(params =>{
      objectId = params['id'];
      if(objectId === ''){
        this.pageTitle = 'Add Ram: ';
      }else {
        this.getRam(objectId);
        this.pageTitle = 'Edit Ram: ';
      }
    });

    this.ramForm = this.formBuilder.group({
      id: [objectId],
      type: 'Ram',
      model: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
      company: ['', [Validators.required, Validators.minLength(3)]],
      price: ['', [Validators.required]],
      powerConsumption: ['', [Validators.required]],
      ramType: ['', [Validators.required]],
      ramSize: ['', [Validators.required]], 
      count: ['', [Validators.required]],
      imageUrl: null,
      infoAbout: [''],
      
    });
  }
  // ramResponse: ServiceResponse<Ram>;
  ramObj: Ram;


  getRam(id: string): void {
    this.ramService.getById(id).subscribe((ramResponse : Ram) => {
      this.ramForm.patchValue({
        ...ramResponse
      });
    });
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.ramForm.controls[controlName].hasError(errorName)
  }
  saveRam(): void {
    if (this.ramForm.dirty && this.ramForm.valid) {
       const ramToSave: Ram = {
         ...this.ramForm.value
       };
       if(ramToSave.infoAbout == null){
         ramToSave.infoAbout = '';
       }
       if(ramToSave.imageUrl == ''){
        ramToSave.imageUrl = 'https://previews.123rf.com/images/lunarismemo/lunarismemo1610/lunarismemo161000184/64828178-ram-%E3%81%AE-labtop-%E8%87%AA%E3%82%89%E3%81%AE%E3%83%A9%E3%83%B3%E3%83%80%E3%83%A0-%E3%82%A2%E3%82%AF%E3%82%BB%E3%82%B9-%E3%83%A1%E3%83%A2%E3%83%AA-4-gb-%E3%81%BE%E3%81%9F%E3%81%AF-8-gb-%E3%81%BE%E3%81%9F%E3%81%AF-16-gb%E3%80%82.jpg';
      }
       this.ramService.saveRam(ramToSave).subscribe(
         () => this.onSaveComplete()
       );
    }
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.ramForm.reset();
    this.router.navigate(['/rams','']);
  }

  
}
