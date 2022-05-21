import { Component } from "./component.model";

  export interface Motherboard extends Component  {
   
        id:string,
        model: string,
        company: string,
        price: number,
        socket: string,
        powerConsumption: number,
        chipset: string,
        formFactor: string,
        ramType:string,
        ramSlots: number,
        type:string,
        imageUrl:string,
        infoAbout:string
    
  } 