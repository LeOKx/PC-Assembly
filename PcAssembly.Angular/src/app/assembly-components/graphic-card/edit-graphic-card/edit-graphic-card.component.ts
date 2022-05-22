import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GraphicCard } from 'src/app/interface/pc-components/graphic-card.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { GraphicCardTableService } from 'src/app/shared/services/graphic-card-table.service';

@Component({
  selector: 'app-edit-graphicCard',
  templateUrl: './edit-graphic-card.component.html',
  styleUrls: ['./edit-graphic-card.component.css']
})
export class EditGraphicCardComponent implements OnInit{


  public pageTitle: string;
  public graphicCardForm: FormGroup;

  graphicCardResp: ServiceResponse<GraphicCard>;
  graphicCard: GraphicCard;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private graphicCardService: GraphicCardTableService
  ) { }

  ngOnInit(): void {
    let objectId: string;
    this.route.params.subscribe(params =>{
      objectId = params['id'];
      if(objectId === ''){
        this.pageTitle = 'Add GraphicCard: ';
      }else {
        this.getGraphicCard(objectId);
        this.pageTitle = 'Edit GraphicCard: ';
      }
    });

    this.graphicCardForm = this.formBuilder.group({
      id: [objectId],
      type: 'GraphicCard',
      model: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
      company: ['', [Validators.required, Validators.minLength(3)]],
      price: ['', [Validators.required]],
      powerConsumption: ['', [Validators.required]],
      sgRamType: ['', [Validators.required]],
      sgRamSize: ['', [Validators.required]],
      imageUrl: null,
      infoAbout: [''],
      
    });
  }
  // graphicCardResponse: ServiceResponse<GraphicCard>;
  graphicCardObj: GraphicCard;


  getGraphicCard(id: string): void {
    this.graphicCardService.getById(id).subscribe((graphicCardResponse : GraphicCard) => {
      this.graphicCardForm.patchValue({
        ...graphicCardResponse
      });
    });
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.graphicCardForm.controls[controlName].hasError(errorName)
  }
  saveGraphicCard(): void {
    if (this.graphicCardForm.dirty && this.graphicCardForm.valid) {
       const graphicCardToSave: GraphicCard = {
         ...this.graphicCardForm.value
       };
       if(graphicCardToSave.infoAbout == null){
         graphicCardToSave.infoAbout = '';
       }
       if(graphicCardToSave.imageUrl == ''){
        graphicCardToSave.imageUrl = 'https://thumbs.dreamstime.com/b/gpu-card-outline-vector-gpu-card-outline-vector-rendering-d-technology-concept-graphics-card-148109545.jpg';
      }
       this.graphicCardService.saveGraphicCard(graphicCardToSave).subscribe(
         () => this.onSaveComplete()
       );
    }
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.graphicCardForm.reset();
    this.router.navigate(['/graphic-cards','']);
  }

  
}
