import { Component, Input, ViewChild } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Subject } from "../subject";
import { HttpService } from "../http.service";

@Component({ selector: "delete-modal", templateUrl: "delete-modal.html", providers: [HttpService] })

export class DeleteModalComponent
{
    @Input() subjects: Subject[];
    @ViewChild("content", { static: false }) content: any;

    constructor(private modal: NgbModal, private httpService: HttpService) { }

    open(subject: Subject)
    {
        this.modal.open(this.content).result.then(() =>
        {
            this.httpService.deleteSubject(subject).subscribe((data: Subject) => this.subjects.splice(this.subjects.map(function (e) { return e.Id; }).indexOf(data.Id), 1), error => console.log(error));
        }, () => { });
    }
}