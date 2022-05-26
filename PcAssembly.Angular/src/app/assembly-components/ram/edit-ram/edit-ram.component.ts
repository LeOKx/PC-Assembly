import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, of } from 'rxjs';
import { Ram } from 'src/app/interface/pc-components/ram.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { RamTableService } from 'src/app/shared/services/ram-table.service';
import { ImageDefault } from 'src/assets/defaultImg/defaultImg.enum';

@Component({
  selector: 'app-edit-ram',
  templateUrl: './edit-ram.component.html',
  styleUrls: ['./edit-ram.component.css']
})
export class EditRamComponent implements OnInit{


  public pageTitle: string;
  public ramForm: FormGroup;
  public showError: boolean = false;
  public errorMessage: string;

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
      model: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
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
       if(ramToSave.imageUrl == '' || ramToSave.imageUrl ==null ){
        ramToSave.imageUrl = ImageDefault.ram;
      }
       this.ramService.saveRam(ramToSave)
       .subscribe(
         () => this.onSaveComplete()
       );
    }
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.ramForm.reset();
    this.router.navigate(['/rams','']);
  }

  setUploadImage(url: string): void {
    this.ramForm.controls['imageUrl'].setValue(url)
  }
}
