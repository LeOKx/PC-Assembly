
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GraphicCard } from 'src/app/interface/pc-components/graphic-card.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { RepositoryService } from './repository.service';

// @Injectable({
//   providedIn: 'root'
// })
@Injectable()
export class GraphicCardTableService extends RepositoryService<GraphicCard>{

    protected override route = "GraphicCards/";
    saveGraphicCard(graphicCard: GraphicCard): Observable<ServiceResponse<GraphicCard>> {
    if (graphicCard.id != '') {
      return super.update(graphicCard.id, graphicCard);
    }
    return super.create(graphicCard);
  }
}
