import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { User } from "./models/user";
import { Event } from "./models/event";
import { EventType } from "./models/event-type";

@Injectable()
export class HttpService
{
    private mainUrl: string = "http://localhost:44307/api/";
    private tokenKey: string = "accessToken";
    private tokenValue: string;

    constructor(private http: HttpClient) { }

    public register(user: User)
    {
        return this.http.post(this.mainUrl + "account/register", user);
    }

    public login(user: User): Observable<any>
    {
        return this.http.post(this.mainUrl + "account/login", user);
    }

    public getUserData()
    {
        let headers = new HttpHeaders();
        headers = headers.set("Authorization", "Bearer " + this.tokenValue);
        return this.http.get(this.mainUrl + "account/getuserdata", { headers: headers, responseType: "json" });
    }

    public authorize(tokenValue: string, rememberMe: boolean)
    {
        this.tokenValue = tokenValue;
        if (rememberMe)
            localStorage.setItem(this.tokenKey, this.tokenValue);
        else
            sessionStorage.setItem(this.tokenKey, this.tokenValue);
    }

    public isAuthorized(): boolean
    {
        this.tokenValue = localStorage.getItem(this.tokenKey);
        if (this.tokenValue == null)
            this.tokenValue = sessionStorage.getItem(this.tokenKey);
        return this.tokenValue != null;
    }

    public logout()
    {
        localStorage.removeItem(this.tokenKey);
        sessionStorage.removeItem(this.tokenKey);
    }

    public addEvent(event: Event): Observable<any>
    {
        return this.http.post(this.mainUrl + "values/addevent", event);
    }

    public editEvent(event: Event): Observable<any>
    {
        return this.http.put(this.mainUrl + "values/editevent", event);
    }

    public deleteEvent(id: number)
    {
        return this.http.delete(this.mainUrl + "values/deleteevent/" + id);
    }

    public changeColor(eventType: EventType): Observable<any>
    {
        return this.http.put(this.mainUrl + "values/changecolor", { id: eventType.id, name: eventType.name, color: eventType.color.primary });
    }
}