import { Component, OnInit } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { AuthenticationService } from './shared/services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'PcAssembly';
  constructor(
    private authService: AuthenticationService, 
    private matIconRegistry: MatIconRegistry,
    private domSanitizer: DomSanitizer
    ){
      this.matIconRegistry.addSvgIcon(
        "computer",
        this.domSanitizer.bypassSecurityTrustResourceUrl("../assets/computer.svg")
      );
      this.matIconRegistry.addSvgIcon(
        "gpu",
        this.domSanitizer.bypassSecurityTrustResourceUrl("../assets/gpu.svg")
      );
      this.matIconRegistry.addSvgIcon(
        "motherboard",
        this.domSanitizer.bypassSecurityTrustResourceUrl("../assets/motherboard.svg")
      );
      this.matIconRegistry.addSvgIcon(
        "power-supply",
        this.domSanitizer.bypassSecurityTrustResourceUrl("../assets/power-supply.svg")
      );
      this.matIconRegistry.addSvgIcon(
        "ram",
        this.domSanitizer.bypassSecurityTrustResourceUrl("../assets/ram.svg")
      );
    }
  
  ngOnInit(): void {
    if(this.authService.isUserAuthenticated())
      this.authService.sendAuthStateChangeNotification(true);
  }
}