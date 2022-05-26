import { AfterViewInit, Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, of } from 'rxjs';
import { AddAssembly } from 'src/app/interface/pc-components/assembly/add-assembly.model';
import { Assembly } from 'src/app/interface/pc-components/assembly/assembly.model';
import { GeneratedAssembly } from 'src/app/interface/pc-components/assembly/GeneratedAssembly.model';
import { UpdateAssembly } from 'src/app/interface/pc-components/assembly/update-assembly.model';
import { ComponentModel } from 'src/app/interface/pc-components/component.model';
import { ServiceResponseSingle } from 'src/app/interface/service-response-single.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { AssemblyService } from 'src/app/shared/services/assembly.service';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { ImageDefault } from 'src/assets/defaultImg/defaultImg.enum';

export interface ComponentInfo {
  id: string,
  name: string;
  imageURl: string;
  delete: boolean;
}

@Component({
  selector: 'app-create-assembly',
  templateUrl: './create-assembly.component.html',
  styleUrls: ['./create-assembly.component.css']
})
export class CreateAssemblyComponent implements OnInit, OnDestroy {

  @ViewChild('create') public create : ElementRef;

  public assemblyForm: FormGroup;
  public totalPriceWithCpu: number;
  public totalPrice: number = 0;
  private coolerPriceAvg = 200;
  private cpuCoolerPrice = 2000;
  public searchByPrice = new FormControl(0,[Validators.required]);;
  public errorMessage: string = '';
  public showError: boolean;
  private  isSelect: boolean = false;
  updateToggle: boolean = false;
  private objectId: string;

  assemblyResp: ServiceResponse<Assembly>;
  assembly: Assembly;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private assemblyService: AssemblyService,
    private acountService: AuthenticationService
  ) { }
  ngOnDestroy(): void {
    if(this.updateToggle && !this.isSelect){
      this.clearLocalStorage();
    }
  }
  setSelectState(selectPath: string){
    this.isSelect = true;
    this.router.navigate([selectPath +'/select'])
  }


  componentInfo: ComponentInfo[] = [
    {name: 'graphicCard', imageURl:'', id: '', delete: false},
    {name: 'ram', imageURl:'', id: '', delete: false},
    {name: 'motherboard', imageURl:'', id: '', delete: false},
    {name: 'cpu', imageURl:'', id: '', delete: false},
    {name: 'powerSupply', imageURl:'', id: '', delete: false},
  ];



  ngOnInit(): void {
    this.assemblyForm = this.formBuilder.group({
      name: ['', [Validators.required]] ,
      cpu: ['', [Validators.required]],
      graphicCard: ['', [Validators.required]],
      motherboard: ['', [Validators.required]],
      ram: ['', [Validators.required]],
      powerSupply: ['', [Validators.required]],
      coolersCount: ['', [Validators.required]],
      userId: [''],
      totalPrice: [''],
      rating: [''],
      imageUrl: ['']
    });
    this.totalPrice = 0;
    this.loadComponentsFromStorage();
    this.updateToggle = false;
    this.route.params.subscribe(params =>{
      this.objectId = params['id'];
      if(this.objectId !== '' && this.objectId !== undefined){
        this.updateToggle = true;
        if(localStorage.getItem('assemblyId') === null){
          this.totalPrice = 0;
          this.getAssembly(this.objectId);
        }
      }
    });
    this.totalPrice = 0;
    this.loadComponentsFromStorage();
    this.assemblyForm.get("coolersCount").valueChanges.subscribe(x => {
      this.getTotalPrice();
   });

    
  }
  getAssembly(id: string): void {
    this.assemblyService.getById(id).subscribe((assemblyResponse : Assembly) => {
      this.clearLocalStorage();
      this.assemblyForm.controls['name'].setValue(assemblyResponse.name);
      this.assemblyForm.controls['imageUrl'].setValue(assemblyResponse.imageUrl);
      this.assemblyForm.controls['coolersCount'].setValue(assemblyResponse.coolersCount);
      localStorage.setItem('assemblyId', JSON.stringify(assemblyResponse.id));
      localStorage.setItem('name', JSON.stringify(assemblyResponse.name));
      localStorage.setItem('imageUrl', JSON.stringify(assemblyResponse.imageUrl));
      localStorage.setItem('coolersCount', JSON.stringify(assemblyResponse.coolersCount));
      localStorage.setItem('cpu', JSON.stringify(assemblyResponse.cpu));
      localStorage.setItem('graphicCard', JSON.stringify(assemblyResponse.graphicCard));
      localStorage.setItem('motherboard', JSON.stringify(assemblyResponse.motherboard));
      localStorage.setItem('ram', JSON.stringify(assemblyResponse.ram));
      localStorage.setItem('powerSupply', JSON.stringify(assemblyResponse.powerSupply));
      this.loadComponentsFromStorage();
    });
  }

  loadComponentsFromStorage(){
    for(let component of this.componentInfo){
      if(localStorage.getItem(component.name)!==null){
        let data = JSON.parse(localStorage.getItem(component.name)) as ComponentModel
        this.assemblyForm.controls[component.name].setValue(data.id)
        component.imageURl = data.imageUrl;
        component.id = data.id;
        component.delete = true;
        this.totalPrice += data.price;
      }else{
        component.delete = false;
        component.id = '';
        switch(component.name){
          case 'cpu':
            component.imageURl = ImageDefault.cpu;
            break;
            case 'graphicCard':
            component.imageURl = ImageDefault.graphicCard;
            break;
            case 'powerSupply':
            component.imageURl = ImageDefault.powerSupply;
            break;
            case 'motherboard':
            component.imageURl = ImageDefault.motherboard;
            break;
            case 'ram':
            component.imageURl = ImageDefault.ram;
            break;
        }
      }
      if(this.updateToggle === true){
        this.objectId = JSON.parse(localStorage.getItem('assemblyId'))
        this.assemblyForm.controls['name'].setValue(JSON.parse(localStorage.getItem('name')));
        this.assemblyForm.controls['imageUrl'].setValue(JSON.parse(localStorage.getItem('imageUrl')));
        this.assemblyForm.controls['coolersCount'].setValue(JSON.parse(localStorage.getItem('coolersCount')));
      }
      
    }
    this.getTotalPrice();
    
  }
  createAssembly(){
    if(this.updateToggle === true){
      this.updateAssembly();
    }else{
    if (this.assemblyForm.dirty && this.assemblyForm.valid) {
      const assemblyToSave: AddAssembly = {
        ...this.assemblyForm.value
      };
      let userId = this.acountService.getUserId();
      if(userId==''){
        userId = '016e12a7-0527-46c8-a2b1-ab7d4be979a2';
      }
      assemblyToSave.userId = userId;
      assemblyToSave.totalPrice = this.getTotalPrice();
      assemblyToSave.rating = 0;

      if(assemblyToSave.imageUrl == ''){
        assemblyToSave.imageUrl = ImageDefault.assembly;
     }
      this.assemblyService.createAssembly(assemblyToSave).subscribe(
        (assembly:ServiceResponseSingle<Assembly>) => this.onSaveComplete(assembly)
      );
   }
  }
  }
  updateAssembly(){
    if (this.assemblyForm.valid) {
      const assemblyToSave: UpdateAssembly = {
        ...this.assemblyForm.value
      };
      assemblyToSave.totalPrice = this.getTotalPrice();
      assemblyToSave.rating = 0;

      if(assemblyToSave.imageUrl == ''){
        assemblyToSave.imageUrl = ImageDefault.assembly;
     }
      this.assemblyService.updateAssembly(this.objectId,assemblyToSave).subscribe(
        (assembly:ServiceResponseSingle<Assembly>) => this.onSaveComplete(assembly)
      );
   }
  }

  onSaveComplete(assemblyResponse: ServiceResponseSingle<Assembly>): void {

    this.clearLocalStorage();
    this.updateToggle = false;
    this.assemblyForm.reset();
    var assembly = assemblyResponse.data as Assembly
    this.router.navigate(['/assembly-info',assembly.id]);
  }
  deleteFromStorage(name: string){
    localStorage.removeItem(name)
    this.loadComponentsFromStorage();
  }
  public getTotalPrice():number{
    let count = this.assemblyForm.controls['coolersCount'].value
    if(count == 0){
      this.totalPriceWithCpu = this.totalPrice;
    }else{
      this.totalPriceWithCpu = this.totalPrice + (count*this.coolerPriceAvg) + this.cpuCoolerPrice;
    }
    return this.totalPriceWithCpu;
  }
  clearLocalStorage(){
    for(let component of this.componentInfo){
      if(localStorage.getItem(component.name)!==null){
        localStorage.removeItem(component.name);
      }
    }
    if(localStorage.getItem('assemblyId')!==null){
      localStorage.removeItem('assemblyId');
      localStorage.removeItem('name');
      localStorage.removeItem('coolersCount');
      localStorage.removeItem('imageUrl');
    }
    this.totalPrice = 0;
    this.loadComponentsFromStorage();
    this.getTotalPrice();
    this.goToStart();
  }
  generateAssembly(){
    this.assemblyService.generateAssembly(this.searchByPrice.value)
    .pipe(
      catchError((error: string) => {
        this.errorMessage = error;
        this.showError = true;
        return of();
    }
    ))
    .subscribe((assembly: GeneratedAssembly) =>{
      this.clearLocalStorage();
      this.showError = false;
      localStorage.setItem('cpu', JSON.stringify(assembly.cpu));
      localStorage.setItem('graphicCard', JSON.stringify(assembly.graphicCard));
      localStorage.setItem('motherboard', JSON.stringify(assembly.motherboard));
      localStorage.setItem('ram', JSON.stringify(assembly.ram));
      localStorage.setItem('powerSupply', JSON.stringify(assembly.powerSupply));
      this.assemblyForm.controls['coolersCount'].setValue(assembly.coolersCount);
      this.loadComponentsFromStorage();
      this.goToStart();
    });
      
  }

  public goToStart():void{
    this.create.nativeElement.scrollIntoView({ behavior: 'smooth', block: 'end', inline: 'start' });
  }
  setUploadImage(url: string): void {
    this.assemblyForm.controls['imageUrl'].setValue(url)
  }

}
