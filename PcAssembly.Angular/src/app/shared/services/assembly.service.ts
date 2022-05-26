import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddAssembly } from 'src/app/interface/pc-components/assembly/add-assembly.model';
import { Assembly } from 'src/app/interface/pc-components/assembly/assembly.model';
import { GeneratedAssembly } from 'src/app/interface/pc-components/assembly/GeneratedAssembly.model';
import { UpdateAssembly } from 'src/app/interface/pc-components/assembly/update-assembly.model';
import { CPU } from 'src/app/interface/pc-components/cpu.model';
import { ServiceResponseSingle } from 'src/app/interface/service-response-single.model';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { PagedResult } from 'src/app/_infrastructure/models/PagedResult';
import { PaginatedRequest } from 'src/app/_infrastructure/models/PaginatedRequest';
import { EnvironmentUrlService } from './enviroment-url.service';
import { RepositoryService } from './repository.service';

// @Injectable({
//   providedIn: 'root'
// })
@Injectable()
export class AssemblyService{

  constructor(protected http: HttpClient, protected envUrl: EnvironmentUrlService) { }

    private route = "Assemblies/";
  public getData(): Observable<ServiceResponse<Assembly>> {
    return this.http.get<ServiceResponse<Assembly>>(this.createCompleteRoute(this.route, this.envUrl.urlAddress), this.generateHeaders());
  }

  public getDataPaged(paginatedRequest: PaginatedRequest): Observable<PagedResult<Assembly>> {
    return this.http.post<PagedResult<Assembly>>(this.createCompleteRoute(this.route, this.envUrl.urlAddress)+'paginated-search', paginatedRequest, this.generateHeaders());
  }

  public getById(id: string): Observable<Assembly> {
    return this.http.get<Assembly>(this.createCompleteRoute(this.route, this.envUrl.urlAddress) + id, this.generateHeaders());
  }

  public delete(id: string) {
    return this.http.delete(this.createCompleteRoute(this.route, this.envUrl.urlAddress) + id, this.generateHeaders());
  }

  public updateAssembly(id: string, body:UpdateAssembly): Observable<ServiceResponseSingle<Assembly>> {
    return this.http.put<ServiceResponseSingle<Assembly>>(this.createCompleteRoute(this.route, this.envUrl.urlAddress) + id, body, this.generateHeaders());
  }

  public createAssembly(body:AddAssembly): Observable<ServiceResponseSingle<Assembly>> {
    return this.http.post<ServiceResponseSingle<Assembly>>(this.createCompleteRoute(this.route, this.envUrl.urlAddress), body, this.generateHeaders());
  }
  public generateAssembly(budget:number): Observable<GeneratedAssembly> {
    return this.http.get<GeneratedAssembly>(this.createCompleteRoute(this.route+"Generate/", this.envUrl.urlAddress) + budget);
  }

  protected createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  protected generateHeaders = () => {
    return {
      headers: new HttpHeaders({
      "Content-Type": "application/json",
      "Authorization": `Bearer ${localStorage.getItem("token")}`
    })
    }
  }
}
