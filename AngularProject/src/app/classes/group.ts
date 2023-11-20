export class Group {
     id: number;
     name: string;
    curator:string;
    constructor(id?: number, name?: string,curator?:string) {
        this.id = id || 0;
        this.name = name || '';
        this.curator=curator||'';

    }
  
}