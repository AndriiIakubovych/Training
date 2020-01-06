import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { Routes, RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { registerLocaleData } from "@angular/common";
import localeRu from "@angular/common/locales/ru";
import { HttpClientModule } from "@angular/common/http";
import { HttpService } from "./http.service";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MaterialAppModule } from "./ngmaterial.module";
import { CalendarModule, DateAdapter } from "angular-calendar";
import { adapterFactory } from "angular-calendar/date-adapters/date-fns";
import { ColorPickerModule } from "ngx-color-picker";
import { RegisterComponent } from "./register/register.component";
import { LoginComponent } from "./login/login.component";
import { CalendarComponent } from "./calendar/calendar.component";
import { CalendarGuard } from "./calendar/calendar.guard";
import { AddEventComponent } from "./calendar/add-event/add-event.component";
import { ShowEventComponent } from "./calendar/show-event/show-event.component";
import { AppComponent } from "./app.component";

registerLocaleData(localeRu);

const routes: Routes = [{ path: "register", component: RegisterComponent }, { path: "login", component: LoginComponent }, { path: "calendar", component: CalendarComponent, canActivate: [CalendarGuard] }, { path: "**", redirectTo: "/calendar" }];

@NgModule({ imports: [BrowserModule, FormsModule, HttpClientModule, BrowserAnimationsModule, MaterialAppModule, CalendarModule.forRoot({ provide: DateAdapter, useFactory: adapterFactory }), RouterModule.forRoot(routes), ColorPickerModule], declarations: [AppComponent, RegisterComponent, LoginComponent, CalendarComponent, AddEventComponent, ShowEventComponent], entryComponents: [AddEventComponent, ShowEventComponent], providers: [HttpService, CalendarGuard], bootstrap: [AppComponent] })
export class AppModule { }