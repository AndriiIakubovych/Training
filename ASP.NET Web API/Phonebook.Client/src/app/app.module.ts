import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { HttpClientModule } from "@angular/common/http";
import { NgxMaskModule, IConfig } from "ngx-mask";
import { AddModalComponent } from "./add-subject/add-modal.component";
import { EditModalComponent } from "./edit-subject/edit-modal.component";
import { DeleteModalComponent } from "./delete-subject/delete-modal.component";
import { SortableHeader, AppComponent } from "./app.component";

export let options: Partial<IConfig> | (() => Partial<IConfig>);

@NgModule({ imports: [BrowserModule, FormsModule, NgbModule, HttpClientModule, NgxMaskModule.forRoot(options)], declarations: [AppComponent, SortableHeader, AddModalComponent, EditModalComponent, DeleteModalComponent], exports: [AppComponent, AddModalComponent, EditModalComponent, DeleteModalComponent], bootstrap: [AppComponent, AddModalComponent, EditModalComponent, DeleteModalComponent] })
export class AppModule { }