import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { ReactiveFormsModule } from "@angular/forms";
import { SwitchButtonComponent } from "./switch-button/switch-button.component";
import { AppComponent } from "./app.component";

@NgModule({ imports: [BrowserModule, FormsModule, ReactiveFormsModule], declarations: [AppComponent, SwitchButtonComponent], exports: [AppComponent, SwitchButtonComponent], bootstrap: [AppComponent] })
export class AppModule { }