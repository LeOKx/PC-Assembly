import { Component } from "./component.model";
export interface Ram extends Component  {
   
        id:string,
        model: string,
        company: string,
        price: number,
        powerConsumption: number,
        type:string,
        imageUrl:string,
        infoAbout:string,
        ramType:string,
        ramSize:number,
        count: number
    
  } 
  