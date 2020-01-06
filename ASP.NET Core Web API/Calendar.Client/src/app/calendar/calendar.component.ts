import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { ActivatedRoute } from '@angular/router';
import { DateAdapter } from "@angular/material";
import { Subject } from "rxjs";
import hexToRgba from "hex-to-rgba";
import { MatDialog } from "@angular/material/dialog";
import { CalendarView, CalendarEvent } from "angular-calendar";
import { AddEventComponent } from "./add-event/add-event.component";
import { ShowEventComponent } from "./show-event/show-event.component";
import { HttpService } from "../http.service";
import { User } from "../models/user";
import { Event } from "../models/event";
import { EventType } from "../models/event-type";

const opacity: number = 0.2;

@Component({ selector: "calendar", templateUrl: "calendar.component.html", styleUrls: ["calendar.component.css"] })
export class CalendarComponent
{
    user: User;
    viewDate: Date = new Date();
    selectedDate: Date = new Date();
    view: CalendarView = CalendarView.Month;
    locale: string = "ru";
    refresh: Subject<any> = new Subject();
    months: string[] = ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"];
    events: Event[] = [];
    calendarEvents: CalendarEvent[] = [];
    eventTypes: EventType[] = [];

    constructor(private httpService: HttpService, private router: Router, route: ActivatedRoute, private dateAdapter: DateAdapter<any>, public addDialog: MatDialog)
    {
        route.queryParams.subscribe(params =>
        {
            this.user = new User(params.id, params.name, params.email);
            for (let value of params.userEventTypeColors)
                this.eventTypes.push(new EventType(value.id, value.name, value.color));
            for (let value of params.events)
            {
                this.events.push(value);
                this.calendarEvents.push({ id: value.id, title: value.name, start: new Date(value.dateStart), end: new Date(value.dateEnd), color: { primary: value.color, secondary: hexToRgba(value.color, opacity) } });
            }
        });
        this.dateAdapter.setLocale(this.locale);
    }

    logout()
    {
        this.httpService.logout();
        this.router.navigate(["/login"]);
    }

    openAddDialog()
    {
        const dialogReference = this.addDialog.open(AddEventComponent, { width: "600px", data: { locale: this.locale } });
        dialogReference.afterClosed().subscribe(data =>
        {
            if (data)
            {
                data.dateStart.setSeconds(0);
                data.dateEnd.setSeconds(0);
                data.userId = this.user.id;
                this.httpService.addEvent(data).subscribe(result =>
                {
                    this.events.push(result);
                    this.calendarEvents = [...this.calendarEvents, { id: result.id, title: result.name, start: new Date(result.dateStart), end: new Date(result.dateEnd), color: { primary: result.color, secondary: hexToRgba(result.color, opacity) } }];
                });
            }
        });
    }

    handleEvent(event: CalendarEvent)
    {
        let requiredEvent: Event = this.events.find(e => e.id == event.id);
        let calendarEvent: CalendarEvent;
        const dialogReference = this.addDialog.open(ShowEventComponent, { width: "600px", data: { locale: this.locale, event: requiredEvent } });
        dialogReference.afterClosed().subscribe(data =>
        {
            if (data)
            {
                if (!data.delete)
                {
                    this.httpService.editEvent(data.event).subscribe(result =>
                    {
                        this.events[this.events.indexOf(this.events.find(e => e.id == result.id))] = result;
                        calendarEvent = this.calendarEvents.find(e => e.id == result.id);
                        calendarEvent = { ...calendarEvent, title: result.name, start: new Date(result.dateStart), end: new Date(result.dateEnd), color: { primary: result.color, secondary: hexToRgba(result.color, opacity) } };
                        this.calendarEvents[this.calendarEvents.indexOf(this.calendarEvents.find(e => e.id == calendarEvent.id))] = calendarEvent;
                        this.refresh.next();
                    });
                }
                else
                    this.httpService.deleteEvent(data.id).subscribe(result =>
                    {
                        this.events = this.events.filter(e => e.id != result);
                        this.calendarEvents = this.calendarEvents.filter(e => e.id != result);
                    });
            }
        });
    }

    changeColor(eventType: EventType)
    {
        this.httpService.changeColor(eventType).subscribe(result =>
        {
            for (let value of result)
                this.calendarEvents.find(e => e.id == value).color = { primary: eventType.color.primary, secondary: hexToRgba(eventType.color.primary, opacity) };
            this.refresh.next();
        });
    }
}