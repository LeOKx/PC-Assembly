import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { UserInfo } from 'src/app/interface/user/userInfo copy';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @Output() public sidenavToggle = new EventEmitter();
  public isUserAuthenticated: boolean;
  public userName: string;

  constructor(private _authService: AuthenticationService, private _router: Router) { }

  ngOnInit() {
    this._authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    });
    this._authService.authUserName
    .subscribe(res => {
      this.userName = res;
    });
    this.isUserAuthenticated = this._authService.isUserAuthenticated();
    if(this.isUserAuthenticated === true){
      this._authService.getUsername(this._authService.getUserId())
      .subscribe((userInfo: UserInfo) => {
        this.userName = userInfo.userName
      });
    }
  }
  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }
  public logout = () => {
    this.userName = '';
    this._authService.logout();
    this._router.navigate(["/"]);
  }

}
