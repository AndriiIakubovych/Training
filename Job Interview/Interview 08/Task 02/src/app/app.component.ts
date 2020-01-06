import { Component } from "@angular/core";
import { FormControl } from "@angular/forms";

@Component({ selector: "main-app", templateUrl: "app.component.html" })
export class AppComponent
{
    outerSwitchValue = true;
    switch: FormControl = new FormControl(false);
}