import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rozetka',
  templateUrl: './rozetka.component.html',
  styleUrls: ['./rozetka.component.css']
})
export class RozetkaComponent implements OnInit {

  @Input() model = '';
  @Input() company = '';

  constructor(private _router: Router) { }

  ngOnInit(): void {
  }
  findAtRozetka(): void{
    window.open(this.createSerchUrl());
  }

  private createSerchUrl():string{
    debugger;
    var company = this.company.replace(/\s+/g, '+')
    var model = this.model.replace(/\s+/g, '+');
    return "https://rozetka.com.ua/ua/search/?text="+company+"+"+model;
  }
}
