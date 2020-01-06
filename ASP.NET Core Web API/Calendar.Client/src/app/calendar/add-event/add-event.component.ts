import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { DateTimeAdapter } from "ng-pick-datetime";
import { Event } from "../../models/event";

@Component({ selector: "add-event", templateUrl: "add-event.component.html", styleUrls: ["add-event.component.css"] })
export class AddEventComponent
{
    event: Event;

    constructor(public dialogReference: MatDialogRef<AddEventComponent>, @Inject(MAT_DIALOG_DATA) public data: string, dateTimeAdapter: DateTimeAdapter<any>)
    {
        this.event = new Event();
        dateTimeAdapter.setLocale(this.data);
    }

    onCancel()
    {
        this.dialogReference.close();
    }
}