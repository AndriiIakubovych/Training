import { Component, Directive, Input, Output, EventEmitter, ViewChild, ViewChildren, QueryList } from "@angular/core";
import { HttpService } from "./http.service";
import { AddModalComponent } from "./add-subject/add-modal.component";
import { EditModalComponent } from "./edit-subject/edit-modal.component";
import { DeleteModalComponent } from "./delete-subject/delete-modal.component";
import { Subject } from "./subject";

export type SortDirection = "asc" | "desc" | "";
const rotate: { [key: string]: SortDirection } = { "asc": "desc", "desc": "", "": "asc" };

export interface SortEvent
{
    column: string;
    direction: SortDirection;
}

@Directive({ selector: "th[sortable]", host: { "[class.asc]": "direction === 'asc'", "[class.desc]": "direction === 'desc'", "(click)": "rotate()" } })
export class SortableHeader
{
    @Input() sortable: string;
    @Input() direction: SortDirection = "";
    @Output() sort = new EventEmitter<SortEvent>();

    rotate()
    {
        this.direction = rotate[this.direction];
        this.sort.emit({ column: this.sortable, direction: this.direction });
    }
}

@Component({ selector: "main-app", templateUrl: "main-app.html", providers: [HttpService] })
export class AppComponent
{
    searchableText: string;
    timerId: any;
    subjects: Subject[] = [];
    prefix: string = "+38 ";
    page: number = 1;
    pageSize: number = 10;
    display: any = "none";
    @ViewChild("addmodal", { static: false }) addModal: AddModalComponent;
    @ViewChild("editmodal", { static: false }) editModal: EditModalComponent;
    @ViewChild("deletemodal", { static: false }) deleteModal: DeleteModalComponent;
    @ViewChildren(SortableHeader) headers: QueryList<SortableHeader>;

    constructor(private httpService: HttpService)
    {
        this.httpService.getSubjects().subscribe((data: Subject[]) => { this.subjects = data; this.display = "block"; });
    }

    search()
    {
        clearTimeout(this.timerId);
        this.timerId = setTimeout(this.filter, 2000, this);
    }

    filter(context: any)
    {
        context.httpService.getFilteredData(context.searchableText).subscribe((data: Subject[]) => { context.subjects = data; });
    }

    openAddModal()
    {
        this.addModal.open();
    }

    openEditModal(subject: Subject)
    {
        this.editModal.open(subject);
    }

    openDeleteModal(subject: Subject)
    {
        this.deleteModal.open(subject);
    }

    onSort({ column, direction }: SortEvent)
    {
        this.headers.forEach(header => { if (header.sortable !== column) { header.direction = ""; } });
        this.httpService.getSortedData(direction).subscribe((data: Subject[]) => { this.subjects = data; });
    }

    get subjectsList(): Subject[]
    {
        return this.subjects.map((subject, i) => ({ id: i + 1, ...subject })).slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
    }

    get subjectsCount(): number
    {
        return this.subjects.length;
    }
}