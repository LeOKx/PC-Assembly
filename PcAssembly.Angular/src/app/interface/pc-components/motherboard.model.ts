import { Component } from "./component.model";

  export interface Motherboard extends Component  {
   
        socket: string,
        chipset: string,
        formFactor: string,
        ramType:string,
        ramSlots: number,
    
  } 