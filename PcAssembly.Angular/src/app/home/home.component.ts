import { Component, OnInit } from '@angular/core';
import { Slick } from 'ngx-slickjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  public executeSelectedChange = (event) => {
    console.log(event);
  }

  slides = [
    {img: "https://localhost:7144/api/images/f0ec9050-2acf-4a89-99b8-2a781fbc008a", 
      link: '/assembly-info/a1ac1110-f3ce-4f49-99f9-42b3d10acbb6',
      alt: "Beautiful Like You!"
    },
    {img: "https://localhost:7144/api/images/00705498-4402-4eba-b35d-09754c988f52", 
      link: '/assembly-info/d25a7943-8a4f-43c8-871b-72820019d772',
      alt: "Gamers will like it"
    },
    {img: "https://localhost:7144/api/images/fabbfd5a-29c6-4d59-9b7f-57b193c257e6", 
      link: '/assembly-info/e9d63fac-a65b-4a1b-9f88-0eaedae46adb',
      alt: "Office Only"
    },
    {img: "https://localhost:7144/api/images/431bd78f-3321-4b48-a824-cc1a72c3145e", 
      link: '/assembly-info/9044a232-8bcd-4c4a-8a5d-9f1cbc198ad1',
      alt: "Enthusiast MAX"
    },
    {img: "https://localhost:7144/api/images/aeafa07c-a1f7-45d2-a243-0bb502543150", 
      link: '/assembly-info/80541cfe-f64d-4a09-92ac-918c2fde1a7e',
      alt: "My Assembly)"
    },
    {img: "https://localhost:7144/api/images/4ad9032a-11ab-4a71-a7e0-4cc13c12abf1", 
      link: '/assembly-info/aa465f28-e801-4d03-978f-fee5df055f43',
      alt: "Boss Of The Gym (by Alexei)"
    },

    
  ];
  
  arrayLength = 10;

  config: Slick.Config = {
      centerMode: true,
      infinite: true,
      slidesToShow: 3,
      slidesToScroll: 1,
      dots: true,
      autoplay: true,
      autoplaySpeed: 2000,
      adaptiveHeight: true,
    }

    getArray(count: number) {
      return new Array(count)
    }

}
