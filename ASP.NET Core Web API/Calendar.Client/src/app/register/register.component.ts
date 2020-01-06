import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { HttpService } from "../http.service";
import { User } from "../models/user";

@Component({ selector: "register", templateUrl: "register.component.html", styleUrls: ["register.component.css"] })
export class RegisterComponent
{
    user: User;
    errors: any;
    errorsEmpty: any = { Name: [], Email: [], Password: [], PasswordConfirm: [] };
    isFormValid: boolean = false;
    isSubmitEnabled: boolean = true;

    constructor(private httpService: HttpService, private router: Router)
    {
        this.user = new User();
        this.errors = this.errorsEmpty;
    }

    onSubmit()
    {
        this.isSubmitEnabled = false;
        this.httpService.register(this.user).subscribe(() =>
        {
            this.isFormValid = true;
            this.errors = this.errorsEmpty;
            setTimeout(() => this.router.navigate(["/calendar"]), 2000);
        },
        result =>
        {
            this.errors = result.error.errors;
            if (this.errors === undefined)
                this.errors = result.error;
            if (this.errors != undefined)
            {
                if (this.errors.Name === undefined)
                    this.errors.Name = this.errorsEmpty.Name;
                if (this.errors.Email === undefined)
                    this.errors.Email = this.errorsEmpty.Email;
                if (this.errors.Password === undefined)
                    this.errors.Password = this.errorsEmpty.Password;
                if (this.errors.PasswordConfirm === undefined)
                    this.errors.PasswordConfirm = this.errorsEmpty.PasswordConfirm;
            }
            else
                this.errors = this.errorsEmpty;
            this.isSubmitEnabled = true;
        });
    }
}