import { CPU } from "../cpu.model";
import { GraphicCard } from "../graphic-card.model";
import { Motherboard } from "../motherboard.model";
import { PowerSupply } from "../power-supply.model";
import { Ram } from "../ram.model";

export interface Assembly{
    id: string,
    name: string,
    cpu: CPU,
    graphicCard: GraphicCard,
    motherboard: Motherboard,
    ram: Ram,
    powerSupply: PowerSupply,
    coolersCount: number,
    userId: string,
    totalPrice: number,
    rating: number,
    imageUrl: string,
    createDate: Date
}