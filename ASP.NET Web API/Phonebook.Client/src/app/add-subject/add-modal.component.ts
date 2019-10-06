import { Component, Input, ViewChild } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Subject } from "../subject";
import { HttpService } from "../http.service";

@Component({ selector: "add-modal", templateUrl: "add-modal.html", providers: [HttpService] })
export class AddModalComponent
{
    subject: Subject;
    @Input() subjects: Subject[];
    @Input() prefix: string;
    @Input() searchable: string;
    @ViewChild("content", { static: false }) content: any;

    constructor(private modal: NgbModal, private httpService: HttpService) { }

    open()
    {
        this.subject = new Subject("", "Физическое лицо", "", "");
        this.modal.open(this.content).result.then(() =>
        {
            this.httpService.addSubject(this.subject, this.searchable).subscribe((data: Subject) =>
            {
                if (data != null)
                    this.subjects.push(data);
            });
        }, () => { });
    }
}