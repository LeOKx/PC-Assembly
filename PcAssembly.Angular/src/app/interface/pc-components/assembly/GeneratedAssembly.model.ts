import { CPU } from "../cpu.model";
import { GraphicCard } from "../graphic-card.model";
import { Motherboard } from "../motherboard.model";
import { PowerSupply } from "../power-supply.model";
import { Ram } from "../ram.model";

export interface GeneratedAssembly{
    cpu: CPU,
    graphicCard: GraphicCard,
    motherboard: Motherboard,
    ram: Ram,
    powerSupply: PowerSupply,
    coolersCount: number,
}