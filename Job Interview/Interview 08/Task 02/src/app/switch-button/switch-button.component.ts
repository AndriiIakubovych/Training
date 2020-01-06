import { Component, Input, forwardRef } from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from "@angular/forms";

@Component({ selector: "switch-button", templateUrl: "switch-button.component.html", styleUrls: ["switch-button.component.css"], providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => SwitchButtonComponent), multi: true }] })
export class SwitchButtonComponent implements ControlValueAccessor
{
    @Input()
    _switchValue = true;
    propagateChange = (_: any) => { };

    writeValue(value: any)
    {
        if (value != undefined)
            this.switchValue = value;
    }

    registerOnChange(fn: any)
    {
        this.propagateChange = fn;
    }

    registerOnTouched() { }

    changeSwitchValue()
    {
        this.switchValue = !this.switchValue;
    }

    get switchValue()
    {
        return this._switchValue;
    }

    set switchValue(value)
    {
        this._switchValue = value;
        this.propagateChange(this._switchValue);
    }
}