export class User
{
    id: number;
    name: string;
    email: string;
    password: string;
    passwordConfirm: string;

    constructor(id?: number, name?: string, email?: string)
    {
        this.id = id;
        this.name = name;
        this.email = email;
    }
}