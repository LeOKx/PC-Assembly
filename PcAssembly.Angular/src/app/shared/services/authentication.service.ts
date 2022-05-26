import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './../../../environments/environment';
import { RegistrationResponseDto } from 'src/app/interface/response/registrationResponseDto';
import { UserForRegistrationDto } from 'src/app/interface/user/userForRegistrationDto';
import { UserForAuthenticationDto } from 'src/app/interface/user/userForAuthenticationDto';
import { AuthResponseDto } from 'src/app/interface/response/authResponseDto';
import { Observable, Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { EnvironmentUrlService } from './enviroment-url.service';
import { UserInfo } from 'src/app/interface/user/userInfo copy';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(private _http: HttpClient, private envUrl: EnvironmentUrlService, private _jwtHelper: JwtHelperService) { }
  private _authChangeSub = new Subject<boolean>();
  private _authUserName = new Subject<string>();
  public authChanged = this._authChangeSub.asObservable();
  public authUserName = this._authUserName.asObservable();


  public registerUser = (route: string, body: UserForRegistrationDto) => {
    return this._http.post<RegistrationResponseDto> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }
  public loginUser = (route: string, body: UserForAuthenticationDto) => {
    return this._http.post<AuthResponseDto> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean, userName?: string) => {
    this._authChangeSub.next(isAuthenticated);
    this._authUserName.next(userName);
  }
  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false,'');
  }
  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");
    return token && !this._jwtHelper.isTokenExpired(token);
  }


  public isUserAdmin = (): boolean => {
    const token = localStorage.getItem("token");
    if(token!=null){
      const decodedToken = this._jwtHelper.decodeToken(token);
      const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      return role === 'Administrator';
    }else{
      return false;
    }
    
  }

  public getUserId = (): string =>{
    const token = localStorage.getItem("token");
    if(token!=null){
      const decodedToken = this._jwtHelper.decodeToken(token);
      const userId = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
      return userId;
    }
    else
    return ''
    
  }

  public getUsername = (userId: string):Observable<UserInfo> =>{
    return this._http.get<UserInfo>(this.envUrl.urlAddress+'/accounts/'+userId, this.generateHeaders());
    
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
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
