import { NgModule } from "@angular/core";
import { MatMomentDateModule } from "@angular/material-moment-adapter";
import { MatButtonModule, MatInputModule, MatTooltipModule, MatDatepickerModule, MatDialogModule, MatIconModule } from "@angular/material";
import { OwlDateTimeModule, OwlNativeDateTimeModule, OwlDateTimeIntl } from "ng-pick-datetime";

export class DefaultIntl extends OwlDateTimeIntl
{
    cancelBtnLabel = "Отмена";
    setBtnLabel = "Установить";
};

@NgModule({ imports: [MatMomentDateModule, MatButtonModule, MatInputModule, MatTooltipModule, MatDatepickerModule, MatDialogModule, MatIconModule, OwlDateTimeModule, OwlNativeDateTimeModule], providers: [{ provide: OwlDateTimeIntl, useClass: DefaultIntl }], exports: [MatMomentDateModule, MatButtonModule, MatInputModule, MatTooltipModule, MatDatepickerModule, MatDialogModule, MatIconModule, OwlDateTimeModule, OwlNativeDateTimeModule] })
export class MaterialAppModule { }