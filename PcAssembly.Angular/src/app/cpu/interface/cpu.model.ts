// export interface CPU {
//     data: [{
//         id:string,
//         model: string,
//         company: string,
//         price: number,
//         socket: string,
//         powerConsumtion: number,
//         family: string,
//         generation: string,
//         cores:number,
//         threads: number,
//         frequency: number,
//         type:string,
//         imageUrl:string,
//         infoAbout:string
//     }],
//     message: string;
//     succes: boolean;
    
//   } 

  export interface CPU {
   
        id:string,
        model: string,
        company: string,
        price: number,
        socket: string,
        powerConsumtion: number,
        family: string,
        generation: string,
        cores:number,
        threads: number,
        frequency: number,
        type:string,
        imageUrl:string,
        infoAbout:string
    
  } 
  
 export const CPU_DATA: CPU[] = [
    {   
        id: "5D3342E7-C17C-4AC2-6FCC-08DA2A9A1E93",
        model: "Intel Core i7-8700K",
        company: "Intel",
        price: 10000,
        socket: "1151",
        powerConsumtion: 180,
        family: "Core i7",
        generation: "CoffeLake",
        cores:6,
        threads: 12,
        frequency: 4.7,
        type:"CPU",
        imageUrl:"",
        infoAbout:""
    },
    {
        id: "00AC546F-C3BD-4C7F-6FCD-08DA2A9A1E93",
        model: "Intel Core i7-9700K",
        company: "Intel",
        price: 11000,
        socket: "1151-v2",
        powerConsumtion: 200,
        family: "Core i7",
        generation: "CoffeLakeRefresh",
        cores:8,
        threads: 8,
        frequency: 4.9,
        type:"CPU",
        imageUrl:"",
        infoAbout:""
    },
    {
        id: "1CB980E5-1235-417F-6FCE-08DA2A9A1E93",
        model: "Intel Core i9-12900K",
        company: "Intel",
        price: 25000,
        socket: "1700",
        powerConsumtion: 300,
        family: "Core i9",
        generation: "Alder Lake",
        cores:16,
        threads: 24,
        frequency: 5.2,
        type:"CPU",
        imageUrl:"",
        infoAbout:""
    }
    
  ];