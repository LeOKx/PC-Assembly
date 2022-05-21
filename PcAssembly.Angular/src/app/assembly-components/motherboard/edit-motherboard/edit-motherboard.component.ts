import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Motherboard } from 'src/app/interface/pc-components/motherboard.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { MotherboardTableService } from 'src/app/shared/services/motherboard-table.service';

@Component({
  selector: 'app-edit-motherboard',
  templateUrl: './edit-motherboard.component.html',
  styleUrls: ['./edit-motherboard.component.css']
})
export class EditMotherboardComponent implements OnInit{


  public pageTitle: string;
  public motherboardForm: FormGroup;

  motherboardResp: ServiceResponse<Motherboard>;
  motherboard: Motherboard;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private motherboardService: MotherboardTableService
  ) { }

  ngOnInit(): void {
    let objectId: string;
    this.route.params.subscribe(params =>{
      objectId = params['id'];
      if(objectId === ''){
        this.pageTitle = 'Add Motherboard: ';
      }else {
        this.getMotherboard(objectId);
        this.pageTitle = 'Edit Motherboard: ';
      }
    });

    this.motherboardForm = this.formBuilder.group({
      id: [objectId],
      type: 'Motherboard',
      model: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
      company: ['', [Validators.required, Validators.minLength(3)]],
      price: ['', [Validators.required]],
      powerConsumption: ['', [Validators.required]],
      socket: ['', [Validators.required]],
      chipset: ['', [Validators.required]],
      formFactor: ['', [Validators.required]],
      ramType: ['', [Validators.required]],
      ramSlots: ['', [Validators.required]],
      imageUrl: null,
      infoAbout: ['', Validators.maxLength(500)],
      
    });
  }
  // motherboardResponse: ServiceResponse<Motherboard>;
  motherboardObj: Motherboard;


  getMotherboard(id: string): void {
    this.motherboardService.getById(id).subscribe((motherboardResponse : Motherboard) => {
      this.motherboardForm.patchValue({
        ...motherboardResponse
      });
    });
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.motherboardForm.controls[controlName].hasError(errorName)
  }
  saveMotherboard(): void {
    if (this.motherboardForm.dirty && this.motherboardForm.valid) {
       const motherboardToSave: Motherboard = {
         ...this.motherboardForm.value
       };
       if(motherboardToSave.infoAbout == null){
         motherboardToSave.infoAbout = '';
       };
       if(motherboardToSave.imageUrl == ''){
        motherboardToSave.imageUrl = 'https://thumbs.dreamstime.com/b/motherboard-pc-icon-doodle-hand-drawn-outline-style-part-computer-software-hardware-set-vector-244860819.jpg';
      };
       this.motherboardService.saveMotherboard(motherboardToSave).subscribe(
         () => this.onSaveComplete()
       );
    }
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.motherboardForm.reset();
    this.router.navigate(['/motherboards','']);
  }

  
}
