import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { HttpService } from "../http.service";
import { User } from "../models/user";

@Component({ selector: "login", templateUrl: "login.component.html", styleUrls: ["login.component.css"] })
export class LoginComponent
{
    user: User;
    errors: any;
    errorsEmpty: any = { Name: [], Password: [] };
    isFormValid: boolean = false;
    rememberMe: boolean = false;
    isSubmitEnabled: boolean = true;
    hasMainError: boolean = false;

    constructor(private httpService: HttpService, private router: Router)
    {
        this.user = new User();
        this.errors = this.errorsEmpty;
    }

    onSubmit()
    {
        this.isSubmitEnabled = false;
        this.httpService.login(this.user).subscribe(result =>
        {
            this.isFormValid = true;
            this.errors = this.errorsEmpty;
            this.hasMainError = false;
            this.httpService.authorize(result.accessToken, this.rememberMe);
            setTimeout(() =>
            {
                this.router.navigate(["/calendar"]);
                this.isFormValid = false;
                this.isSubmitEnabled = true;
            }, 2000);
        },
        result =>
        {
            this.errors = result.error.errors;
            if (this.errors === undefined)
                this.errors = result.error.error;
            if (this.errors != undefined)
            {
                this.hasMainError = this.errors.Name === undefined && this.errors.Password === undefined;
                if (this.errors.Name === undefined)
                    this.errors.Name = this.errorsEmpty.Name;
                if (this.errors.Password === undefined)
                    this.errors.Password = this.errorsEmpty.Password;
            }
            else
            {
                this.errors = this.errorsEmpty;
                this.hasMainError = true;
            }
            this.isSubmitEnabled = true;
        });
    }
}