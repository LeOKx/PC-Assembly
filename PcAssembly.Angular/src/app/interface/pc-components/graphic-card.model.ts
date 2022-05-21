import { Component } from "./component.model";

export interface GraphicCard extends Component  {
   
        id:string,
        model: string,
        company: string,
        price: number,
        powerConsumption: number,
        type:string,
        imageUrl:string,
        infoAbout:string,
        sgRamType:string,
        sgRamSize:number
    
  } 
  