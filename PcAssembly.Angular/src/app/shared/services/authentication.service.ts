import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './../../../environments/environment';
import { RegistrationResponseDto } from 'src/app/interface/response/registrationResponseDto';
import { UserForRegistrationDto } from 'src/app/interface/user/userForRegistrationDto';
import { UserForAuthenticationDto } from 'src/app/interface/user/userForAuthenticationDto';
import { AuthResponseDto } from 'src/app/interface/response/authResponseDto';
import { Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { EnvironmentUrlService } from './enviroment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(private _http: HttpClient, private envUrl: EnvironmentUrlService, private _jwtHelper: JwtHelperService) { }
  private _authChangeSub = new Subject<boolean>()
  public authChanged = this._authChangeSub.asObservable();


  public registerUser = (route: string, body: UserForRegistrationDto) => {
    return this._http.post<RegistrationResponseDto> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }
  public loginUser = (route: string, body: UserForAuthenticationDto) => {
    return this._http.post<AuthResponseDto> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this._authChangeSub.next(isAuthenticated);
  }
  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }
  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");
 
    return token && !this._jwtHelper.isTokenExpired(token);
  }

  public isUserAdmin = (): boolean => {
    const token = localStorage.getItem("token");
    const decodedToken = this._jwtHelper.decodeToken(token);
    const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    return role === 'Administrator';
  }

  public getUserId = (): string =>{
    const token = localStorage.getItem("token");
    const decodedToken = this._jwtHelper.decodeToken(token);
    const userId = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
    return userId;
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

}
