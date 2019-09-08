export class Subject
{
    Id: number;
    Name: string;
    Type: string;
    Address: string;
    Telephone: string;

    constructor(name: string, type: string, address: string, telephone: string)
    {
        this.Name = name;
        this.Type = type;
        this.Address = address;
        this.Telephone = telephone;
    }
}