import { Component, Input, ViewChild } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Subject } from "../subject";
import { HttpService } from "../http.service";

@Component({ selector: "edit-modal", templateUrl: "edit-modal.component.html", providers: [HttpService] })
export class EditModalComponent
{
    subject: Subject;
    @Input() subjects: Subject[];
    @Input() prefix: string;
    @ViewChild("content", { static: false }) content: any;

    constructor(private modal: NgbModal, private httpService: HttpService) { }

    open(subject: Subject)
    {
        this.subject = new Subject(subject.Name, subject.Type, subject.Address, subject.Telephone);
        this.subject.Id = subject.Id;
        this.modal.open(this.content).result.then(() =>
        {
            this.httpService.editSubject(this.subject).subscribe((data: Subject) =>
            {
                subject.Name = data.Name;
                subject.Type = data.Type;
                subject.Address = data.Address;
                subject.Telephone = data.Telephone;
                for (let i = 0; i < this.subjects.length; i++)
                    if (this.subjects[i].Id === this.subject.Id)
                    {
                        this.subjects[i].Name = subject.Name;
                        this.subjects[i].Type = subject.Type;
                        this.subjects[i].Address = subject.Address;
                        this.subjects[i].Telephone = subject.Telephone;
                        break;
                    }
            }, error => console.log(error));
        }, () => { });
    }
}