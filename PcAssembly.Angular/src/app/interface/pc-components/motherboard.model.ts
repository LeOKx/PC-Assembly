import { ComponentModel } from "./component.model";

  export interface Motherboard extends ComponentModel  {
   
        socket: string,
        chipset: string,
        formFactor: string,
        ramType:string,
        ramSlots: number,
    
  } 