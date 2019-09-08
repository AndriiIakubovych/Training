import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Subject } from "./subject";

@Injectable()
export class HttpService
{
    private mainUrl = "http://localhost:64377/api/values/";

    constructor(private http: HttpClient) { }

    getSubjects()
    {
        return this.http.get(this.mainUrl + "getsubjects");
    }

    addSubject(subject: Subject, text: string)
    {
        if (text === "")
            text = "undefined";
        return this.http.post(this.mainUrl + "addsubject/" + text, subject);
    }

    editSubject(subject: Subject)
    {
        return this.http.put(this.mainUrl + "editsubject", subject);
    }

    deleteSubject(subject: Subject)
    {
        return this.http.delete(this.mainUrl + "deletesubject/" + subject.Id);
    }

    getFilteredData(text: string)
    {
        let params = new HttpParams().set("text", text);
        return this.http.get(this.mainUrl + "getfiltereddata", { params: params });
    }

    getSortedData(direction: string)
    {
        let params = new HttpParams().set("direction", direction);
        return this.http.get(this.mainUrl + "getsorteddata", { params: params });
    }
}