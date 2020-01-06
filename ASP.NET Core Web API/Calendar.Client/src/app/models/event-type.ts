export class EventType
{
    id: number;
    name: string;
    color: any;

    constructor(id: number, name: string, color: string)
    {
        this.id = id;
        this.name = name;
        this.color = { primary: color, secondary: color };
    }
}