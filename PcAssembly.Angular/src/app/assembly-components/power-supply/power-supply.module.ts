import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PowerSupplyListComponent } from './power-supply-list/power-supply-list.component';
import { MaterialModule } from 'src/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ImageUploadModule } from 'src/app/image-upload/image-upload.module';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { PowerSupplyTableService } from 'src/app/shared/services/power-supply-table.service';
import { PowerSupplyInfoComponent } from './power-supply-info/power-supply-info.component';
import { EditPowerSupplyComponent } from './edit-power-supply/edit-power-supply.component';
import { PowerSupplyRoutingModule } from './power-supply-routing/power-supply-routing.module';
import { RozetkaModule } from 'src/app/rozetka-search/rozetka/rozetka.module';



@NgModule({
  declarations: [
    PowerSupplyListComponent,
    EditPowerSupplyComponent,
    PowerSupplyInfoComponent
  ],
  imports: [
    CommonModule,
    PowerSupplyRoutingModule,
    ReactiveFormsModule,
    ImageUploadModule,
    MaterialModule,
    RozetkaModule
  ],
  exports:[
    PowerSupplyInfoComponent
  ],
  providers: [
    PowerSupplyTableService,
    AuthenticationService
  ]
})
export class PowerSupplyModule { }
