import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from './../../../environments/environment';
import { EnvironmentUrlService } from './enviroment-url.service';
import { Observable } from 'rxjs';
import { ServiceResponse } from 'src/app/interface/service-response.model';
import { PaginatedRequest } from 'src/app/_infrastructure/models/PaginatedRequest';
import { PagedResult } from 'src/app/_infrastructure/models/PagedResult';
@Injectable({
  providedIn: 'root'
})
export class RepositoryService<T>{
  constructor(protected http: HttpClient, protected envUrl: EnvironmentUrlService) { }

  protected route: string;

  public getData(): Observable<ServiceResponse<T>> {
    return this.http.get<ServiceResponse<T>>(this.createCompleteRoute(this.route, this.envUrl.urlAddress), this.generateHeaders());
  }

  public getDataPaged(paginatedRequest: PaginatedRequest): Observable<PagedResult<T>> {
    return this.http.post<PagedResult<T>>(this.createCompleteRoute(this.route, this.envUrl.urlAddress)+'paginated-search', paginatedRequest, this.generateHeaders());
  }

  public getById(id: string): Observable<T> {
    return this.http.get<T>(this.createCompleteRoute(this.route, this.envUrl.urlAddress) + id, this.generateHeaders());
  }

  public delete(id: string) {
    return this.http.delete(this.createCompleteRoute(this.route, this.envUrl.urlAddress) + id, this.generateHeaders());
  }

  public update(id: string, body:T): Observable<ServiceResponse<T>> {
    return this.http.put<ServiceResponse<T>>(this.createCompleteRoute(this.route, this.envUrl.urlAddress) + id, body, this.generateHeaders());
  }

  public create(body:T): Observable<ServiceResponse<T>> {
    return this.http.post<ServiceResponse<T>>(this.createCompleteRoute(this.route, this.envUrl.urlAddress), body, this.generateHeaders());
  }
 
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  public getClaims = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress), this.generateHeaders());
  }
 
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({
      "Content-Type": "application/json",
      "Authorization": `Bearer ${localStorage.getItem("token")}`
    })
    }
  }
}