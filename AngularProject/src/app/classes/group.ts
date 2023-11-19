import { BasicItem } from "../interfaces/basic-item";

export class Group implements BasicItem{
    id: number;
    name: string;
    constructor(id: number, name: string) {
        this.id = id;
        this.name = name;
    }
}