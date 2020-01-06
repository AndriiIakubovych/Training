export class Event
{
    id: number;
    name: string;
    dateStart: Date;
    dateEnd: Date;
    location: string;
    description: string;
    userId: number;

    constructor(id?: number, name?: string, dateStart?: Date, dateEnd?: Date, location?: string, description?: string)
    {
        this.id = id;
        this.name = name;
        this.dateStart = dateStart;
        this.dateEnd = dateEnd;
        this.location = location;
        this.description = description;
    }
}