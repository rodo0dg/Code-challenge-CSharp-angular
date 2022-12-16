import { Component, EventEmitter, Output } from "@angular/core";

@Component({
    selector: 'auth-remember',
    template: `
    <label>
        <input type="checkbox" (change)="onChecked($event.target)">
        Keep me logged in
    </label>`
})
export class AuthRememberComponent {
    @Output() checked: EventEmitter<boolean> = new EventEmitter<boolean>();

    onChecked(value: EventTarget | null) {
        this.checked.emit((value as HTMLInputElement)?.checked);
    }
}