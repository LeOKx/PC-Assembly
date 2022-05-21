import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @Output() public sidenavToggle = new EventEmitter();
  public isUserAuthenticated: boolean;

  constructor(private _authService: AuthenticationService, private _router: Router) { }

  ngOnInit() {
    this._authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    });
    this.isUserAuthenticated = this._authService.isUserAuthenticated();
  }
  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }
  public logout = () => {
    this._authService.logout();
    this._router.navigate(["/"]);
  }

}
