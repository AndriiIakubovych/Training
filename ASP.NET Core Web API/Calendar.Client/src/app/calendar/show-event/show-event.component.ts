import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { DateTimeAdapter } from "ng-pick-datetime";
import { Event } from "../../models/event";

@Component({ selector: "show-event", templateUrl: "show-event.component.html", styleUrls: ["show-event.component.css"] })
export class ShowEventComponent
{
    event: Event;

    constructor(public dialogReference: MatDialogRef<ShowEventComponent>, @Inject(MAT_DIALOG_DATA) public data: any, dateTimeAdapter: DateTimeAdapter<any>)
    {
        let dateStart = this.data.event.dateStart;
        let dateEnd = this.data.event.dateEnd;
        this.event = new Event(this.data.event.id, this.data.event.name, new Date(dateStart), new Date(dateEnd), this.data.event.location, this.data.event.description);
        dateTimeAdapter.setLocale(this.data.locale);
        setTimeout(() => { this.event.dateStart = new Date(dateStart); this.event.dateEnd = new Date(dateEnd); }, 500);
    }

    onCancel()
    {
        this.dialogReference.close();
    }
}