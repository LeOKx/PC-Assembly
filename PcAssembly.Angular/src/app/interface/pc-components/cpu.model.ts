import { Component } from "./component.model";

export interface CPU extends Component {

        socket: string,
        family: string,
        generation: string,
        cores:number,
        threads: number,
        frequency: number,
  } 