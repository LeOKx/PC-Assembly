import { ComponentModel } from "./component.model";

export interface CPU extends ComponentModel {

        socket: string,
        family: string,
        generation: string,
        cores:number,
        threads: number,
        frequency: number,
  } 