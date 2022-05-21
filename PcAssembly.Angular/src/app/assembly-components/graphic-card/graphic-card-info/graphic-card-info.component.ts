import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { Location } from '@angular/common';
import { GraphicCard } from 'src/app/interface/pc-components/graphic-card.model';
import { GraphicCardTableService } from 'src/app/shared/services/graphic-card-table.service';

@Component({
  selector: 'app-graphic-card-info',
  templateUrl: './graphic-card-info.component.html',
  styleUrls: ['./graphic-card-info.component.css']
})
export class GraphicCardInfoComponent implements OnInit {

  public graphicCardData: GraphicCard;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private graphicCardService: GraphicCardTableService
  ) { }

  ngOnInit(): void {
    let objectId: string;
    this.route.params.subscribe(params =>{
      objectId = params['id'];
        this.getGraphicCard(objectId);
    });
  }

  getGraphicCard(id: string): void {
    this.graphicCardService.getById(id).subscribe((graphicCardResponse : GraphicCard) => {
      this.graphicCardData = graphicCardResponse
    });
  }
  back(): void {
    this.location.back();
  }

}
